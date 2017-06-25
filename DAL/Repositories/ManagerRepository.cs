using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace DAL
{
    public class ManagerRepository:IRepository<manager>
    {
        private Model db;

        public ManagerRepository()
        {
            this.db = new Model();
        }

        public IEnumerable<manager> GetAllObject()
        {
            return db.manager;
        }

        public manager GetObject(int id)
        {
            return db.manager.Find(id);
        }

        public void Create(manager book)
        {
            db.manager.Add(book);
        }

        public void Update(manager book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            manager book = db.manager.Find(id);
            if (book != null)
                db.manager.Remove(book);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
