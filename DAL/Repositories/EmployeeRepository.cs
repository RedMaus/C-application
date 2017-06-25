using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace DAL
{
    public class EmployeeRepository:IRepository<employee>
    {
        private Model db;

        public EmployeeRepository()
        {
            this.db = new Model();
        }

        public IEnumerable<employee> GetAllObject()
        {
            return db.employee;
        }

        public employee GetObject(int id)
        {
            return db.employee.Find(id);
        }

        public void Create(employee book)
        {
            db.employee.Add(book);
        }

        public void Update(employee book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            employee book = db.employee.Find(id);
            if (book != null)
                db.employee.Remove(book);
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
