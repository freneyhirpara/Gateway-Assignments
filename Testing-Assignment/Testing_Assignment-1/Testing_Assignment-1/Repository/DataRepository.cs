using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Testing_Assignment_1.Models;

namespace Testing_Assignment_1.Repository
{
    public class DataRepository : IDataRepository
    {
        readonly Dictionary<Guid, Passenger> _passenger = new Dictionary<Guid, Passenger>();
        public DataRepository()
        {
            Guid id1 = new Guid();
            Guid id2 = new Guid();
            Guid id3 = new Guid();
            _passenger.Add(id1, new Passenger() { Id = id1, FirstName = "Freney", LastName = "Hirpara" ,PhoneNumber = "9876543210"});
            _passenger.Add(id2, new Passenger() { Id = id2, FirstName = "Palak", LastName = "Agrawal", PhoneNumber = "9898987889" });
            _passenger.Add(id3, new Passenger() { Id = id3, FirstName = "Ayushi", LastName = "Tikoo", PhoneNumber = "9879879876" });

        }
        public Passenger AddPassenger(Passenger passenger)
        {
            Guid _Id = new Guid();
            passenger.Id = _Id;
            _passenger.Add(_Id, passenger);
            return passenger;
        }

        public bool Delete(Guid Id)
        {
            var results = _passenger.Remove(Id);
            return results;
        }

        public Passenger GetById(Guid id)
        {
            return _passenger.FirstOrDefault(x => x.Key == id).Value;
        }

        public Passenger Update(Passenger passenger)
        {
            Passenger ob = GetById(passenger.Id);
            if (ob == null)
                return null;
            _passenger[ob.Id] = passenger;
            return passenger;
        }

        public IList<Passenger> getPassengersList()
        {
            return _passenger.Select(x => x.Value).ToList();
        }

        
    }
}