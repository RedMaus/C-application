using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace DAL
{
    public class MessagerRepository:IRepository<messager>
    {
        private Model db;

        public MessagerRepository()
        {
            this.db = new Model();
        }

        public IEnumerable<messager> GetAllObject()
        {
            return db.messager;
        }

        public messager GetObject(int id)
        {
            return db.messager.Find(id);
        }

        public void Create(messager book)
        {
            db.messager.Add(book);
        }

        public void Update(messager book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            messager book = db.messager.Find(id);
            if (book != null)
                db.messager.Remove(book);
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
