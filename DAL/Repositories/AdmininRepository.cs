using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace DAL
{
    public class AdmininRepository:IRepository<adminin>
    {
        private Model db;

        public AdmininRepository()
        {
            this.db = new Model();
        }

        public IEnumerable<adminin> GetAllObject()
        {
            return db.adminin;
        }

        public adminin GetObject(int id)
        {
            return db.adminin.Find(id);
        }

        public void Create(adminin book)
        {
            db.adminin.Add(book);
        }

        public void Update(adminin book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            adminin book = db.adminin.Find(id);
            if (book != null)
                db.adminin.Remove(book);
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
