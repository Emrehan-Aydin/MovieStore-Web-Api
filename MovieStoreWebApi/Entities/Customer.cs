using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreWebApi.Entities
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<CustomerMovie> Customer_Movie_Lib { get; set; }
        public List<CustomerGenre> Customer_Genre_Lib { get; set; }
    }
}