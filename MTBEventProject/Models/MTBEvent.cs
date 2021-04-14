using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace MTBEventProject.Models
{
    public class MTBEvent

    {
        [Key]
        public int MTBEventID { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string MTBEventTitle { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string MTBEventLocation { get; set; }

        [Column(TypeName = "text")]
        public string MTBEventDescription { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string MTBEventWebsite { get; set; }

        [DataType(DataType.Date)]
        public DateTime MTBEventDate { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string MTBEventGroup { get; set; }
    }

}