using MediteerApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediteerApp.Data.Context
{
    public class MediteerContext : DbContext
    {
        public MediteerContext(DbContextOptions options) : base(options) { }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Meditation> Meditations { get; set; }
 
    }
}

