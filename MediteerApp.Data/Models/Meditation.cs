using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediteerApp.Data.Models
{
    public class Meditation
    {
        public Guid Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
    }
}
