using CleanArch.Application.AutoMapper;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Services;

using CleanArch.Domain.CommandHandler;
using CleanArch.Domain.CommandHandler.ApplicationUers;
using CleanArch.Domain.CommandHandler.Categories;
using CleanArch.Domain.CommandHandler.Companies;
using CleanArch.Domain.CommandHandler.OrderDetails;
using CleanArch.Domain.CommandHandler.OrderHeaders;
using CleanArch.Domain.CommandHandler.ProductImages;
using CleanArch.Domain.CommandHandler.Products;
using CleanArch.Domain.CommandHandler.ShoppingCarts;
using CleanArch.Domain.CommandHandler.types;
using CleanArch.Domain.Commands;
using CleanArch.Domain.Commands.ApplicationUers;
using CleanArch.Domain.Commands.Categorys;
using CleanArch.Domain.Commands.Companies;
using CleanArch.Domain.Commands.OrderDetails;
using CleanArch.Domain.Commands.OrderHeaders;
using CleanArch.Domain.Commands.ProductImages;
using CleanArch.Domain.Commands.Products;
using CleanArch.Domain.Commands.ShoppingCarts;
using CleanArch.Domain.Commands.types;
using CleanArch.Domain.Core.Bus;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Repository;
using Microsoft.AspNetCore.Cors.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArch.Infra.Bus;
using CleanArch.Domain.Commands.Service;
using CleanArch.Domain.CommandHandler.Services;

namespace CleanArch.Infra.Ioc
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {

            //services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer(Config.DbConnection()));

            services.AddMediatR(typeof(DependencyContainer));
            services.AddAutoMapper(typeof(AutoMapperConfiguration));

            // Domain InMemoryBus MediatR
            services.AddScoped<IMediatorHandler, InMemoryBus>();


            // Domain Handler
 
            services.AddScoped<IRequestHandler<CreateCategoryCommand, bool>, CreateCategoryCommandHandler>();
            services.AddScoped<IRequestHandler<EditCategoryCommand, bool>, EditCategoryCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteCategoryCommand, bool>, DeleteCategoryCommandHandler>();


            services.AddScoped<IRequestHandler<CreateProductCommand, bool>, CreateProductCommandHandler>();
            services.AddScoped<IRequestHandler<EditProductCommand, bool>, EditProductCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteProductCommand, bool>, DeleteProductCommandHandler>();


            services.AddScoped<IRequestHandler<CreateProductImageCommand, bool>, CreateProductImageCommandHandler>();
            services.AddScoped<IRequestHandler<EditProductImageCommand, bool>, EditProductImageCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteProductImageCommand, bool>, DeleteProductImageCommandHandler>();

            services.AddScoped<IRequestHandler<CreatetypeCommand, bool>, CreatetypeCommandHandler>();
            services.AddScoped<IRequestHandler<EdittypeCommand, bool>, EdittypeCommandHandler>();
            services.AddScoped<IRequestHandler<DeletetypeCommand, bool>, DeletetypeCommandHandler>();

            services.AddScoped<IRequestHandler<CreateCompanyCommand, bool>, CreateCompanyCommandHandler>();
            services.AddScoped<IRequestHandler<EditCompanyCommand, bool>, EditCompanyCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteCompanyCommand, bool>, DeleteCompanyCommandHandler>();

            services.AddScoped<IRequestHandler<CreateShopingCartCommand, bool>, CreateShopingCartCommandHandler>();
            services.AddScoped<IRequestHandler<EditShoppingCartCommand, bool>, EditShopingCartCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteShopingCartCommand, bool>, DeleteShopingCartCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteRangShopingCartCommand, bool>, DeleteRangeShopingCartCommandHandler>();

            services.AddScoped<IRequestHandler<CreateApplicationUserCommand, bool>, CreateApplicationUserCommandHandler>();
            services.AddScoped<IRequestHandler<EditApplicationUserCommand, bool>, EditApplicationUserCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteApplicationUserCommand, bool>, DeleteApplicationUserCommandHandler>();

            services.AddScoped<IRequestHandler<CreateOrderHeaderCommand, bool>, CreateOrderHeaderCommandHandler>();
            services.AddScoped<IRequestHandler<EditOrderHeaderCommand, bool>, EditOrderHeaderCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteOrderHeaderCommand, bool>, DeleteOrderHeaderCommandHandler>();

            services.AddScoped<IRequestHandler<CreateOrderDetailCommand, bool>, CreateOrderDetailCommandHandler>();
            services.AddScoped<IRequestHandler<EditOrderDetailCommand, bool>, EditOrderDetailCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteOrderDetailCommand, bool>, DeleteOrderDetailCommandHandler>();

            services.AddScoped<IRequestHandler<CreateServiceCommand, bool>, CreateServiceCommandHandler>();
            services.AddScoped<IRequestHandler<EditServiceCommand, bool>, EditServiceCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteServiceCommand, bool>, DeleteServiceCommandHandler>();




            // application layer

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductImageService, ProductImageService>();
            services.AddScoped<ItypeService, typeService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IShoppingCartService, ShopingCartService>();
            services.AddScoped<IApplicationUserService, ApplicationUserService>();
            services.AddScoped<IOrderHeaderService, OrderHeaderService>();
            services.AddScoped<IOrderDetailService, OrderDetailService>();
            services.AddScoped<IServiceService, ServiceService>();

            // Infra.Data  Layer
          


            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductImageRepository, ProductImageRepository>();
            services.AddScoped<ItypeRepository, typeRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            services.AddScoped<IOrderHeaderRepository, OrderHeaderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();

            //services.AddScoped<UniversityDBContext>();

        }



    }
}