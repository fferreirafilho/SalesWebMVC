using System;
using System.Linq;

namespace SalesWebMVC.Services.Exceptions {
    public class NotFoundException : ApplicationException {
        public NotFoundException(String message) : base(message) { }
    }
}
