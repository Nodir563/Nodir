using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Shop
    {
        [Key]
        public int ItemId { get; set; }
        [Column(TypeName ="nvarchar(250)")]
        [Required(ErrorMessage ="My only friend, this field is required")]
        [DisplayName("Singer Name")]
        public string SingerName { get; set; }
        [Column(TypeName = "varchar(10)")]
        [DisplayName("Album Name")]
        public string AlbumName { get; set; }
        [Column(TypeName = "varchar(100)")]
        [DisplayName("Popular Song")]
        public string PopularSong { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Homeland { get; set; }
    }
}
