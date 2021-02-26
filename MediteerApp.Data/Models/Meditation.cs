using System;
using System.Collections.Generic;
using System.Text;

namespace MediteerApp.Data.Models
{
    public class Meditation
    {
        public Guid Id { get; set; }
        public Guid CollectionId { get; set; }
        public string Name { get; set; }
    }
}
