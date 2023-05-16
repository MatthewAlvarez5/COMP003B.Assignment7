using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace COMP003B.Assignment7.Models
{
    public class Song
    {
        public int SongId { get; set; }
        [Required]
        public string SongName { get; set; }
        [Required]
        public string SongGenre { get; set; }
        [Required]
        public string SongAlbum { get; set;}
        
        public virtual ICollection<Song>? Songs { get;set; }

        public int ReleaseYear { get; set; } // New Property
    }
}
