using System.ComponentModel.DataAnnotations.Schema;

namespace CampSleepway_TeamGaJoL
{
     public  class Person
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }  
        public required string LastName { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Sex { get; set; }
        public required int Age { get; set; }
    }
}
