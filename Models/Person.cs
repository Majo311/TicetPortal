namespace TicetPortal.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberType { get; set; }
        
        public Person(string firstName, string lastName, string phoneNumber, string PhoneNumberType)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
            this.PhoneNumberType = PhoneNumberType;
        }
    }
}
