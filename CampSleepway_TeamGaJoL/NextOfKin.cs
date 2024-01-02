using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSleepway_TeamGaJoL
{
    public class NextOfKin : Person
    {
        public int? CamperId { get; set; } // måste sättas till null av någon anledning, löses med kod i programmet så det måste vara kopplat.
        public virtual Camper? Camper { get; set; } // måste vara ansluten till en camper
        public int? CounselorId { get; set; } // FÅR vara ansluten till en counselor, måste ej
        public virtual Counselor? Counselor { get; set; }// FÅR vara ansluten till en counselor, måste ej
        

        // Potentiell framtida lösning på ifall vi vill visa namn i databasen på andra
        // ställen än på bara persons
        //[Column("First Name")]
        //public string Firstname
        //{
        //    get
        //    {
        //        var associatedPerson = GetAssociatedPerson.AssociatedPerson(Id);
        //        return associatedPerson.FirstName;
        //    }
        //}

        //[Column("Last Name")]
        //public string Lastname
        //{
        //    get
        //    {
        //        var associatedPerson = GetAssociatedPerson.AssociatedPerson(Id);
        //        return associatedPerson.LastName;
        //    }
        //}
    }
}
