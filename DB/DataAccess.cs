using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class DataAccess
    {
        private static DataAccess instance = null; 


        private DataAccess()
        {

        }
        public static DataAccess Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataAccess();
                }
                return instance;
            }
        }
        public string GetConnectionString()
        {
            return "Server=kraka.ucn.dk;Database=dmaa0916_201960;User Id=dmaa0916_201960;Password=Password1!;Integrated Security=false;MultipleActiveResultSets=true";
        }

    }
}
