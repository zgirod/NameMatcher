using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Names.Domain.Abstract;

namespace Names.Domain.Concrete
{
    public class NameMatcher : INameMatcher
    {

        INicknameRepository _nicknameRepo = null;

        public NameMatcher(INicknameRepository nicknameRepo)
        {
            _nicknameRepo = nicknameRepo;
        }

        public IEnumerable<string> GetAllPossibleNames(string fullName)
        {

            //these are the possible names we are going to return
            fullName = fullName.Trim();
            var names = new List<string>() { fullName };

            //get the first name of the person
            //because we only care about the nick names for first names
            var firstName = fullName.Split(new char[] { ' ' }).FirstOrDefault();

            //get all the kick names for the first name
            var possibleOtherNames = _nicknameRepo.GetMatchingNames(firstName);

            //if we have other possible names
            if (possibleOtherNames != null)
            {
                //for each possible nick name
                foreach (var possibleName in possibleOtherNames)
                {

                    //replace the first name with a possible other name
                    //I am doing it this way opposed to a replace because the first name could be repeated in the last name
                    names.Add(possibleName + fullName.Substring(firstName.Length));

                }

            }

            //return all the names we have
            return names;

        }

        public bool AreNamesEqual(string sourceName, string verificationName)
        {

            //check if the possible names matches a name you passed in
            return this.GetAllPossibleNames(sourceName).Contains(verificationName);

        }
    }
}
