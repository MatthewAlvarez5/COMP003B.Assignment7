using System.ComponentModel.DataAnnotations;

namespace COMP003B.Assignment7.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }
        [Required]
        public string ArtistAlias { get; set; }
        [Required]
        public string ArtistFirstName { get; set; }
        [Required]
        public string ArtistLastName { get; set; }
        [Required]
        public string ArtistGenre { get; set; }
    }
}
