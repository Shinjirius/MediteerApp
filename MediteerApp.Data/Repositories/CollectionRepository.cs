using MediteerApp.Data.Context;
using MediteerApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediteerApp.Data.Repositories
{
    public class CollectionRepository
    {
        public CollectionRepository(MediteerContext context)
        {
            _context = context;
        }

        private MediteerContext _context;

        public Collection Get(Guid id) => _context.Collections.FirstOrDefault(m => m.Id == id);
        public IEnumerable<Collection> GetAll() => _context.Collections;


        public void Add(Guid id, string name)
        {
            var collection = new Collection { Id = id, Name = name };
            _context.Collections.Add(collection);
            _context.SaveChanges();
        }

        public void Rename(Guid id, string name)
        {
            var collection = new Collection { Id = id, Name = name };
            _context.Collections.Update(collection);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var collection = new Collection { Id = id };
            _context.Collections.Attach(collection);
            _context.Collections.Remove(collection);
            _context.SaveChanges();
        }
    }
}
