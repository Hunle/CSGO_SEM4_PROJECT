using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSGO_MVC.Models;

namespace DB.Arnes_Repo
{
    public class Reposistory<T> : IRepository<T> where T : class
    {
        private SteamAccountContext dbConnection;
        private DbSet<T> dbSet; 

        public Reposistory()
        {
            dbConnection = new SteamAccountContext();
            dbSet = dbConnection.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public T GetById(object Id)
        {
            return dbSet.Find(Id);
        }

        public void Insert(T obj)
        {
            dbSet.Add(obj);
        }
        public void Update(T obj)
        {
            dbConnection.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object Id)
        {
            T getObjById = dbSet.Find(Id);
            dbSet.Remove(getObjById);
        }
        public void Save()
        {
            dbConnection.SaveChanges();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.dbConnection != null)
                {
                    this.dbConnection.Dispose();
                    this.dbConnection = null;
                }
            }
        }



    }
}
