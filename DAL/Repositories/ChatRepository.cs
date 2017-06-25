using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace DAL
{
    public class ChatRepository:IRepository<chat>
    {
        private Model db;

        public ChatRepository()
        {
            this.db = new Model();
        }

        public IEnumerable<chat> GetAllObject()
        {
            return db.chat;
        }

        public chat GetObject(int id)
        {
            return db.chat.Find(id);
        }

        public void Create(chat book)
        {
            db.chat.Add(book);
        }

        public void Update(chat book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            chat book = db.chat.Find(id);
            if (book != null)
                db.chat.Remove(book);
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
