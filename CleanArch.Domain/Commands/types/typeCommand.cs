using CleanArch.Domain.Core.Commands;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Commands.types
{
    public  class typeCommand : Command
    {
        public int Id { get; set; }

        public string Name { get; protected set; }
        public int DisplayOrder { get; protected set; }
    }
}
