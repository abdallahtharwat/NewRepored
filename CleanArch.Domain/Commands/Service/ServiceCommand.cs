using CleanArch.Domain.Core.Commands;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Commands.Service
{
    public class ServiceCommand : Command
    {
        public int Id { get; set; }

        public service Service { get; set; }

    }
}
