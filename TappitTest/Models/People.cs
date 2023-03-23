using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace TappitTest.Models
{
    public class People
    {
        [Key]
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAuthorised { get; set; }
        public bool IsValid { get; set; }
        public bool IsEnabled { get; set; }

        public List<FavouriteSports> FavouriteSports { get; set; }


        public object ToDto()
        {
            return new
            {
                PersonId = PersonId,
                FirstName = FirstName,
                LastName = LastName,
                IsAuthorised = IsAuthorised,
                IsValid = IsValid,
                Enabled = IsEnabled,
                FavouriteSports = FavouriteSports?.Select(x => x.Sports.Name)
            };          
        }
    }
}
