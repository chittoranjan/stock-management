using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagement.Models.EntityModels;
using StockManagement.Repositories;

namespace StockManagement.BLL
{
    public class PartyManager
    {
        PartyRepository repository=new PartyRepository();
        public bool Add(Party party)
        {
            if (string.IsNullOrEmpty(party.Name))
            {
                throw new Exception("Party name is not provided!");
            }
            if (string.IsNullOrEmpty(party.ContactNo))
            {
                throw  new Exception("party contact no is not provided!");
            }
            return repository.Add(party);
        }

        public bool Update(Party party)
        {
            return repository.Update(party);
        }

        public bool Remove(Party party)
        {
            return repository.Remove(party);
        }

        public List<Party> PartyList(bool withDeleted=false)
        {
            return repository.PartyList(withDeleted);
        }

        public Party GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Dispose()
        {
            repository.Dispose();
        }
    }
}
