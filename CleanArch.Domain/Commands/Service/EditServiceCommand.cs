using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Commands.Service
{
    public class EditServiceCommand : ServiceCommand
    {
        public EditServiceCommand( service  service )
        {
              
            Service = service;
            
        }
    }
}
