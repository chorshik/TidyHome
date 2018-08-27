using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TidyHome2.DAL.DB.Interfaces;
using TidyHome2.DAL.Entities.EF;
using System.Data.Entity;

namespace TidyHome2.DAL.DB.Repository
{
    public class BaseRepository<T> where T : class
    {
        private ApplicationDbContext _dataContext;
        protected IDbSet<T> Context { get; }
        protected ApplicationDbContext DataContext => _dataContext ?? (_dataContext = DatabaseFactory.Get());

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        public BaseRepository(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            Context = DataContext.Set<T>();
        }

        public void Save()
        {
            DataContext.SaveChanges();
        }
    }
}
