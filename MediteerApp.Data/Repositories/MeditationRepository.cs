using MediteerApp.Data.Context;
using MediteerApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediteerApp.Data.Repositories
{
    public class MeditationRepository
    {
        public MeditationRepository(MediteerContext context)
        {
            _context = context;
        }

        private MediteerContext _context;

        public Meditation Get(Guid id) => _context.Meditations.FirstOrDefault(m => m.Id == id);
        public IEnumerable<Meditation> GetAll(Guid collectionId) => _context.Collections.FirstOrDefault(m => m.Id == collectionId)?.Meditations;


        public void Add(Guid id, string name, Guid collectionId) 
        {
            var meditation = new Meditation { Id = id, Name = name };
            _context.Collections.FirstOrDefault(m => m.Id == collectionId).Meditations.Add(meditation);
            _context.SaveChanges();
        }

        public void Rename(Guid id, string name)
        {
            var meditation = new Meditation { Id = id, Name = name };
            _context.Meditations.Update(meditation);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var meditation = new Meditation { Id = id };
            _context.Meditations.Attach(meditation);
            _context.Meditations.Remove(meditation);
            _context.SaveChanges();
        }
    }
}
