using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using ACR2.Core.Models;

namespace ACR2.Models
{
    public class School
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}