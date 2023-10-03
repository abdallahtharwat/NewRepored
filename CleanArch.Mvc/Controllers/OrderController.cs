using CleanArch.Application.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Domain.ViewModel;
using CleanArch.Mvc.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;
using System.Security.Claims;

namespace CleanArch.Mvc.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderHeaderService _orderHeaderService;
        private readonly IOrderDetailService _orderDetailService;
        [BindProperty]
        public OrderVM OrderVM { get; set; }
        public OrderController(IOrderHeaderService orderHeaderService , IOrderDetailService orderDetailService )
        {
            _orderHeaderService = orderHeaderService;
            _orderDetailService = orderDetailService;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Details(int OrderId)
        {
            OrderVM = new()
            {
                OrderHeader = _orderHeaderService.Get(u => u.Id == OrderId, includeproperties: "ApplicationUser"),
                OrderDetails = _orderDetailService.GetAll(u => u.OrderHeaderId == OrderId, includeproperties: "Product")

            };

            return View(OrderVM);
        }


        [HttpPost]
        [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Employee)]
        public IActionResult UpdateOrderDetail()
        {
            var orderHeaderFromDb = _orderHeaderService.Get(u => u.Id == OrderVM.OrderHeader.Id); // when we post we need order header id 

            orderHeaderFromDb.Name = OrderVM.OrderHeader.Name;  // name the user will write in page == name in datebase
            orderHeaderFromDb.PhoneNumber = OrderVM.OrderHeader.PhoneNumber;
            orderHeaderFromDb.StreetAddress = OrderVM.OrderHeader.StreetAddress;
            orderHeaderFromDb.City = OrderVM.OrderHeader.City;
            orderHeaderFromDb.State = OrderVM.OrderHeader.State;
            orderHeaderFromDb.PostalCode = OrderVM.OrderHeader.PostalCode;
            orderHeaderFromDb.Build = OrderVM.OrderHeader.Build;
            orderHeaderFromDb.apartment = OrderVM.OrderHeader.apartment;

            if (!string.IsNullOrEmpty(OrderVM.OrderHeader.Carrier))
            {
                orderHeaderFromDb.Carrier = OrderVM.OrderHeader.Carrier; // update
            }
            if (!string.IsNullOrEmpty(OrderVM.OrderHeader.TrackingNumber))
            {
                orderHeaderFromDb.Carrier = OrderVM.OrderHeader.TrackingNumber; // update
            }

            _orderHeaderService.Update(orderHeaderFromDb);
            //_UnitofWork.Save();

            TempData["Success"] = "Order Details Updated Successfully.";


            return RedirectToAction(nameof(Details), new { OrderId = orderHeaderFromDb.Id });
        }



        [HttpPost]
        [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Employee)]
        public IActionResult StartProcessing()
        {
            _orderHeaderService.UpdateStatus(OrderVM.OrderHeader.Id, SD.StatusInProcess); // ht3ml update le status mn approve to inprocess
            //_UnitofWork.Save();
            TempData["Success"] = "Order Details Update Successfully";
            return RedirectToAction(nameof(Details), new { OrderId = OrderVM.OrderHeader.Id });

        }


        [HttpPost]
        [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Employee)]
        public IActionResult ShipOrder()
        {

            var orderHeader = _orderHeaderService.Get(u => u.Id == OrderVM.OrderHeader.Id);   // when we want to shipp the order we want to retrive that from database
            orderHeader.TrackingNumber = OrderVM.OrderHeader.TrackingNumber;
            orderHeader.Carrier = OrderVM.OrderHeader.Carrier;
            orderHeader.OrderStatus = SD.StatusShipped;
            orderHeader.ShippingDate = DateTime.Now;
            if (orderHeader.PaymentStatus == SD.PaymentStatusDelayedPayment)
            {
                orderHeader.PaymentDueDate = DateTime.Now.AddDays(30);
            }

            _orderHeaderService.Update(orderHeader);
            //_UnitofWork.Save();
            TempData["Success"] = "Order Shipped Successfully.";
            return RedirectToAction(nameof(Details), new { orderId = OrderVM.OrderHeader.Id });
        }


        [HttpPost]
        [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Employee)]
        public IActionResult CancelOrder()   // when we need cancel order we need change the status it will be cancel and we want to give refund to this customer based on paymentintentid to use stripe
        {
            var orderHeader = _orderHeaderService.Get(u => u.Id == OrderVM.OrderHeader.Id); // when we want to cancel the order we want to retrive that from database

            if (orderHeader.PaymentStatus == SD.PaymentStatusApproved)
            {
                var options = new RefundCreateOptions       // in order to give them refund we will create a variable options of new refund
                {
                    Reason = RefundReasons.RequestedByCustomer,
                    PaymentIntent = orderHeader.PaymentIntentId // retrive that
                };

                var service = new RefundService();    // create a refund service with stripe
                Refund refund = service.Create(options);
                _orderHeaderService.UpdateStatus(orderHeader.Id, SD.StatusCancelled, SD.StatusRefunded);
            }
            else
            {
                _orderHeaderService.UpdateStatus(orderHeader.Id, SD.StatusCancelled, SD.StatusCancelled);
            }
            //_UnitofWork.Save();
            TempData["Success"] = "Order Cancelled Successfully.";
            return RedirectToAction(nameof(Details), new { orderId = OrderVM.OrderHeader.Id });

        }



        [ActionName("Details")]
        [HttpPost]
        public IActionResult Details_PAY_NOW()   // pay now for compay user
        {
            OrderVM.OrderHeader = _orderHeaderService.Get(u => u.Id == OrderVM.OrderHeader.Id, includeproperties: "ApplicationUser");
            OrderVM.OrderDetails = _orderDetailService.GetAll(u => u.OrderHeaderId == OrderVM.OrderHeader.Id, includeproperties: "Product");

            //stripe logic
            var domain = Request.Scheme + "://" + Request.Host.Value + "/";
            var options = new SessionCreateOptions
            {
                SuccessUrl = domain + $"order/PaymentConfirmation?orderHeaderId={OrderVM.OrderHeader.Id}",
                CancelUrl = domain + $"order/details?orderId={OrderVM.OrderHeader.Id}",
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
            };

            foreach (var item in OrderVM.OrderDetails)
            {
                var sessionLineItem = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)(item.Price * 100), // $20.50 => 2050
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = item.Product.Title
                        }
                    },
                    Quantity = item.Count
                };
                options.LineItems.Add(sessionLineItem);
            }


            var service = new SessionService();
            Session session = service.Create(options);
            _orderHeaderService.UpdateStripePaymentID(OrderVM.OrderHeader.Id, session.Id, session.PaymentIntentId);
            //_UnitofWork.Save();
            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }


        public IActionResult PaymentConfirmation(int orderHeaderId)
        {

            OrderHeader orderHeader = _orderHeaderService.Get(u => u.Id == orderHeaderId);
            if (orderHeader.PaymentStatus == SD.PaymentStatusDelayedPayment)
            {
                //this is an order by company

                var service = new SessionService();
                Session session = service.Get(orderHeader.SessionId);

                if (session.PaymentStatus.ToLower() == "paid")
                {
                    _orderHeaderService.UpdateStripePaymentID(orderHeaderId, session.Id, session.PaymentIntentId);
                    _orderHeaderService.UpdateStatus(orderHeaderId, orderHeader.OrderStatus, SD.PaymentStatusApproved);
                    //_UnitofWork.Save();
                }


            }

            return View(orderHeaderId);
        }





        #region API CALLS
        [HttpGet]
        public IActionResult GetAll(string status)
        {

            IEnumerable<OrderHeader> objorderheaders = _orderHeaderService.GetAll(includeproperties: "ApplicationUser").ToList();


            if (User.IsInRole(SD.Role_Admin) || User.IsInRole(SD.Role_Employee))   // see all the order in order mange
            {
                objorderheaders = _orderHeaderService.GetAll(includeproperties: "ApplicationUser").ToList();   // get orderheader and show it in view

            }
            else        // el uesr byshof el orders bta3tth bas   in order mange
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

                objorderheaders = _orderHeaderService.GetAll(u => u.ApplicationUserId == userId, includeproperties: "ApplicationUser");
            }




            switch (status)
            {
                case "pending":
                    objorderheaders = objorderheaders.Where(u => u.PaymentStatus == SD.PaymentStatusDelayedPayment);
                    break;
                case "inprocess":
                    objorderheaders = objorderheaders.Where(u => u.OrderStatus == SD.StatusInProcess);
                    break;
                case "completed":
                    objorderheaders = objorderheaders.Where(u => u.OrderStatus == SD.StatusShipped);
                    break;
                case "approved":
                    objorderheaders = objorderheaders.Where(u => u.OrderStatus == SD.StatusApproved);
                    break;
                default:
                    break;

            }

            return Json(new { data = objorderheaders });

        }

        #endregion



    }
}
