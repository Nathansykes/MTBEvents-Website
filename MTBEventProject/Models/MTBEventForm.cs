using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace MTBEventProject.Models
{
    public class MTBEventForm

    {
        [Key]
        public int MTBEventID { get; set; }
        
        public string MTBEventTitle { get; set; }

        public string MTBEventLocation { get; set; }

        public string MTBEventDescription { get; set; }

        public string MTBEventWebsite { get; set; }

        [DataType(DataType.Date)]
        public DateTime MTBEventDate { get; set; }

        public string MTBEventGroup { get; set; }
    }

}