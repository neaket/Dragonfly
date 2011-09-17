using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Indicle.Dragonfly.Models.Transformers.Exceptions
{
    public class TransformerException : Exception
    {
        public TransformerException() {}
        public TransformerException(string message) : base(message) { }
        public TransformerException(string message, Exception innerException) : base(message, innerException) { }
    }
}
