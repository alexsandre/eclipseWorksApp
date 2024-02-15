using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EclipseWorksApp.Domain.Exceptions
{
    public class DomainException : InvalidOperationException
    {
        public DomainException(string message) : base(message) { }
    }
}
