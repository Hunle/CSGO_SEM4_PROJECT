using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DB
{
    public class BaseRepository
    
        {
            protected DataAccess context;
            public BaseRepository()
            {
                context = new DataAccess();
            }
        }
    }

    