using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace DAL
{
    public class ComandRepository:IRepository<comand>
    {
        private Model db;

        public ComandRepository()
        {
            this.db = new Model();
        }

        public IEnumerable<comand> GetAllObject()
        {
            return db.comand;
        }

        public comand GetObject(int id)
        {
            return db.comand.Find(id);
        }

        public void Create(comand book)
        {
            db.comand.Add(book);
        }

        public void Update(comand book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            comand book = db.comand.Find(id);
            if (book != null)
                db.comand.Remove(book);
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
