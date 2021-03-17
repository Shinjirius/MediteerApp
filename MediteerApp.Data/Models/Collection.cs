using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediteerApp.Data.Models
{
    public class Collection
    {
        public Guid Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }
        public ICollection<Meditation> Meditations { get; set; }
    }
}
