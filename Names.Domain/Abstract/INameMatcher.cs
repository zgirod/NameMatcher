using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Names.Domain.Abstract
{
    public interface INameMatcher
    {
        IEnumerable<string> GetAllPossibleNames(string fullName);
        bool AreNamesEqual(string sourceName, string verificationName);
    }
}
