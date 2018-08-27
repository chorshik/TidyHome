using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TidyHome2.DAL.Entities.EF;

namespace TidyHome2.DAL.DB.Interfaces
{
    public interface IDatabaseFactory
    {
        ApplicationDbContext Get();
    }
}
