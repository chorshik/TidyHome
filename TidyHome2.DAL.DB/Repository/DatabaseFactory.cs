using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TidyHome2.DAL.Entities.Entities;
using TidyHome2.DAL.DB.Interfaces;
using TidyHome2.DAL.Entities.EF;


namespace TidyHome2.DAL.DB.Repository
{
    public class DatabaseFactory: IDatabaseFactory
    {
        private ApplicationDbContext _dataContext;
        public ApplicationDbContext Get()
        {
            return _dataContext ?? (_dataContext = new ApplicationDbContext());
        }
    }
}
