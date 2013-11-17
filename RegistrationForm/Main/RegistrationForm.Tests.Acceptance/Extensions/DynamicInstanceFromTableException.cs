using System;

namespace RegistrationForm.Tests.Acceptance
{
    public class DynamicInstanceFromTableException : Exception
    {
        public DynamicInstanceFromTableException(string message) : base(message) { }
    }
}