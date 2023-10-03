using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Core.Events
{
    public abstract class Messageint : IRequest<int>
    {
        public string MessageType { get; protected set; }

        protected Messageint()
        {
            MessageType = GetType().Name;
        }

    }
}
