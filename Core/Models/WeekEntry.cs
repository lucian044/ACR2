using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using ACR2.Core.Models;

namespace ACR2.Models
{
    public class WeekEntry
    {
        public int Id { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Required]
        public int Mon { get; set; }
        [Required]
        public int Tue { get; set; } 
        [Required]
        public int Wed { get; set; }
        [Required]
        public int Thurs { get; set; }
        [Required]
        public int Fri { get; set; }
        [Required]
        public int WeekId { get; set; }
        public Week Week { get; set; }
        public string Auth0Id { get; set; }
        [Required]
        public DateTime LastUpdated { get; set; }
        public ICollection<Photo> Photos { get; set; }

        public WeekEntry()
        {
            Photos = new Collection<Photo>();
        }
    }
}