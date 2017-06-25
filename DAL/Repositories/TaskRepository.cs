using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace DAL
{
    public class TaskRepository:IRepository<task>
    {
        private Model db;

        public TaskRepository()
        {
            this.db = new Model();
        }

        public IEnumerable<task> GetAllObject()
        {
            return db.task;
        }

        public task GetObject(int id)
        {
            return db.task.Find(id);
        }

        public void Create(task book)
        {
            db.task.Add(book);
        }

        public void Update(task book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            task book = db.task.Find(id);
            if (book != null)
                db.task.Remove(book);
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
