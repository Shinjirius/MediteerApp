using MediteerApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediteerApp.Data.Repositories
{
    public class MeditationRepository
    {
        private List<Meditation> _meditaties = new List<Meditation>()
        {
            new Meditation() { Id = Guid.NewGuid(), CollectionId = Guid.Parse("74E1ABD2-9143-41B2-8704-A4C77B6B6300")},
            new Meditation() { Id = Guid.NewGuid(), CollectionId = Guid.Parse("74E1ABD2-9143-41B2-8704-A4C77B6B6300")},
            new Meditation() { Id = Guid.NewGuid(), CollectionId = Guid.NewGuid()}
        };

        public Meditation Get(Guid id) => _meditaties.Find(m => m.Id == id);
        public IEnumerable<Meditation> GetAll(Guid collectionId) => _meditaties.FindAll(m => m.CollectionId == collectionId);
    }
}
