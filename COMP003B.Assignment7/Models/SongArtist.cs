using System.ComponentModel.DataAnnotations;

namespace COMP003B.Assignment7.Models
{
    public class SongArtist
    {
        public int Id { get; set; }
        public int SongId { get; set; }
        public int ArtistId { get; set; }
        public virtual Song? Song { get; set; }
        public virtual Artist? Artist { get; set; }

    }
}
