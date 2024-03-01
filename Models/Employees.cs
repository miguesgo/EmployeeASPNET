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
             *   (1) first character correspond to the first letter of the first last name
             *   (2) then the first vowel of the first last name
             *   (3) then the first letter of the second last name
             *   (4) then the first letter of the name
             *   (5) then the year in 2 digits
             *   (6) then the month in 2 digits
             *   (7) then the day in 2 digits
             *   (8) then 3 unique values
             */
            set
            {
                //Validate the lenght of the RFC
                if (value.Length == 13)
                {
                    string firstVocalRFC = "";
                    
                    // Validation (1)
                    if (value.Substring(0, 1) == LastNameP.Substring(0, 1).ToUpper())
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

                        // Validation (2)
                        if (value.Substring(1, 1) == firstVocalRFC &&
                                // Validation (3)
                                value.Substring(2, 1) == LastNameM.Substring(0, 1).ToUpper() &&
                                // Validation (4)
                                value.Substring(3, 1) == Name.Substring(0, 1).ToUpper() &&
                                // Validation (5)
                                value.Substring(4, 2) == BornDate.ToString("yy") &&
                                // Validation (6)
                                value.Substring(6, 2) == BornDate.ToString("MM") &&
                                // Validation (7)
                                value.Substring(8, 2) == BornDate.ToString("dd"))
                        {
                            // Validation (8)
                            // Since the RFC is lenght 13, the next 3 characters are special
                            _rfc = value;
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
