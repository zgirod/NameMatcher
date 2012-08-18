using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Names.Domain.Objects;
using Names.Domain.Abstract;

namespace Names.Domain.Concrete
{
    public class TestNicknameRepository : INicknameRepository
    {

        private List<Nickname> _nickNames = new List<Nickname>()
        {
            new Nickname() { OriginalName = "Richard", NickName = "Rick" },
            new Nickname() { OriginalName = "Richard", NickName = "Rich" },
            new Nickname() { OriginalName = "Richard", NickName = "Dick" },
            new Nickname() { OriginalName = "Zachary", NickName = "Zach" },
            new Nickname() { OriginalName = "Zachary", NickName = "Zack" },
            new Nickname() { OriginalName = "Zachary", NickName = "Zac" }
        };


        public IEnumerable<string> GetMatchingNames(string name)
        {

            //if we don't have a name
            if (String.IsNullOrWhiteSpace(name))
                return null;

            //return all the possible names
            return _nickNames.Where(x => x.NickName == name).Select(x => x.OriginalName)
                .Union(_nickNames.Where(x => x.OriginalName == name).Select(x => x.NickName)).ToList();

        }

    }
}
