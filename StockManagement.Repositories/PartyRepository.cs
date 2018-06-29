using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using StockManagement.Models.DatabaseContext;
using StockManagement.Models.EntityModels;

namespace StockManagement.Repositories
{
    public class PartyRepository
    {
        StockDBContext db=new StockDBContext();
        public bool Add(Party party)
        {
            db.Parties.Add(party);
            return db.SaveChanges() > 0;
        }

        public bool Update(Party party)
        {
            db.Parties.Attach(party);
            db.Entry(party).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public bool Remove(Party party)
        {
            party.IsDeleted = true;
            return Update(party);
        }

        public List<Party> PartyList(bool withDeleted = false)
        {
            return db.Parties.Where(c => c.IsDeleted == withDeleted).ToList();
        }

        public Party GetById(int id)
        {
            return db.Parties.FirstOrDefault(c => c.Id == id);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
