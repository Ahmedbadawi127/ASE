using System;

namespace Shipping.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException()
            : base()
        {
        }

        public NotFoundException(string message)
            : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public NotFoundException(string name, object key)
            : base($"Entity \"{name}\" ({key}) was not found.")
        {
        }
    }

    public class BEValidationException : Exception
    {
        public BEValidationException()
            : base()
        {
        }

        public BEValidationException(string message)
            : base(message)
        {
        }

    }

    public class BETransactiException : Exception
    {
        public BETransactiException()
            : base()
        {
        }

        public BETransactiException(string message)
            : base(message)
        {
        }

    }
}
