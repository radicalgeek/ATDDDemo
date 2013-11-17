using System;
using System.Collections.Generic;

namespace RegistrationForm.Tests.Acceptance
{
    public class DynamicInstanceComparisonException : Exception
    {
        public IList<string> Differences { get; private set; }

        public DynamicInstanceComparisonException(IList<string> diffs)
            : base("There were some difference between the table and the instance")
        {
            Differences = diffs;
        }
    }
}