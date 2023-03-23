using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace TappitTest.Models
{
    [PrimaryKey(nameof(PersonId), nameof(SportId))]
    public class FavouriteSports
    {
        [ForeignKey("PersonId")]
        public int PersonId { get; set; }
        [ForeignKey("SportId")]
        public int SportId { get; set; }

        public People People { get; set; }
        public Sports Sports { get; set; }
    }
}
