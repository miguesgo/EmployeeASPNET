namespace CandidateTest.Models
{
    public class Employees
    {
        private string _rfc;

        public int ID { get; set; }
        public string Name { get; set; }
        public string LastNameP { get; set; }
        public string LastNameM { get; set; }
        public string RFC {
            get { return _rfc; }
            set
            {
                if (value.Length == 13)
                {
                    string firstLetter = value.Substring(0, 1);
                    string firstVocal = "";
                    string secondLetterRFC = value.Substring(1, 1);
                    string thirdLetterRFC = value.Substring(1, 2);
                    //System.Diagnostics.Debug.WriteLine("AAAAAAAAAAAAAAaaa: " + secondLetter);
                    if (firstLetter == LastNameP.Substring(0, 1)){

                        for (int i=1; i< LastNameP.Length; i++)
                        {

                            if ((LastNameP.Substring(i, 1).ToUpper() == "A") || (LastNameP.Substring(i, 1).ToUpper() == "E") || (LastNameP.Substring(i, 1).ToUpper() == "I") || (LastNameP.Substring(i, 1).ToUpper() == "O") || (LastNameP.Substring(i, 1).ToUpper() == "U")) {
                                firstVocal = LastNameP.Substring(i, 1).ToUpper();
                                break;
                            }
                        }

                        if (secondLetterRFC == firstVocal)
                        {
                            _rfc = value;
                        }

                        //_rfc = value;
                    }
                }
            }
        }
        public DateTime BornDate { get; set; }
        public EmployeeStatus Status { get; set; }

    }

    public enum EmployeeStatus
    {
        NotSet,
        Active,
        Inactive,
    }
}
