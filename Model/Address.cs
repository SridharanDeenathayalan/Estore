using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace Estore.Model
{
    public class Address
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        
        public AppUser AppUser { get; set; }
        [ForeignKey("AppUserId")]
        public string AppUserId { get; set; }
    }
}