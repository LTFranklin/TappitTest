using System.ComponentModel.DataAnnotations;

namespace TappitTest.Models
{
    public class Sports
    {
        [Key]
        public int SportId { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }

        public List<FavouriteSports> FavouriteSports { get; set; }

        public object ToDto()
        {
            return new
            {
                SportId = SportId,
                Name = Name,
                IsEnabled = IsEnabled,
                Favourited = FavouriteSports?.Count
            };
        }
    }
}
