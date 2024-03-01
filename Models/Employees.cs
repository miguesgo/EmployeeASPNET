namespace CandidateTest.Models
{
    public class Employees
    {
        //Variable to set and get the RFC
        private string _rfc;
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastNameP { get; set; }
        public string LastNameM { get; set; }
        public DateTime BornDate { get; set; }
        public string RFC {
            get { return _rfc; }
            
            /*  == Validation of the RFC ==
             *  The RFC is composed by 13 character word with the
             *   - first character correspond to the first letter of the first last name
             *   - then the first vowel of the first last name
             *   - then the first letter of the second last name
             *   - then the first letter of the name
             *   - then the year in 2 digits
             *   - then the month in 2 digits
             *   - then the day in 2 digits
             *   - then 3 unique values
             */
            set
            {
                //Validate the lenght of the RFC
                if (value.Length == 13)
                {
                    string firstLetterRFC = value.Substring(0, 1);
                    string firstVocalRFC = "";
                    string secondLetterRFC = value.Substring(1, 1);
                    string thirdLetterRFC = value.Substring(2, 1);
                    string fourthLetterRFC = value.Substring(3, 1);
                    string yearRFC = value.Substring(4, 2);
                    string monthRFC = value.Substring(6, 2);
                    string dayRFC = value.Substring(8, 2);
                    
                    if (firstLetterRFC == LastNameP.Substring(0, 1).ToUpper())
                    {
                        //For to retrieve all the letter of the first last name until it detect a vowel 
                        for (int i = 1; i < LastNameP.Length; i++)
                        {
                            //Retrive the first vocal of the first last name to compare to the 2nd letter in the RFC
                            if ((LastNameP.Substring(i, 1).ToUpper() == "A") || (LastNameP.Substring(i, 1).ToUpper() == "E") || (LastNameP.Substring(i, 1).ToUpper() == "I") || (LastNameP.Substring(i, 1).ToUpper() == "O") || (LastNameP.Substring(i, 1).ToUpper() == "U")) {
                                firstVocalRFC = LastNameP.Substring(i, 1).ToUpper();
                                break;
                            }
                        }

                        if (secondLetterRFC == firstVocalRFC)
                        {
                            if (thirdLetterRFC == LastNameM.Substring(0, 1).ToUpper())
                            {
                                if (fourthLetterRFC == Name.Substring(0, 1).ToUpper())
                                {
                                    if (yearRFC == BornDate.ToString("yy"))
                                    {
                                        if (monthRFC == BornDate.ToString("MM"))
                                        {
                                            if (dayRFC == BornDate.ToString("dd"))
                                            {
                                                _rfc = value;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public EmployeeStatus Status { get; set; }
    }

    public enum EmployeeStatus
    {
        NotSet,
        Active,
        Inactive,
    }
}
