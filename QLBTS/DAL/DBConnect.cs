using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBConnect
    {
        protected SqlConnection cnn = new SqlConnection(@"Data Source=DESKTOP-KQ52HT2\SQLEXPRESS;Initial Catalog=QLBTS;Integrated Security=True");

    }
}
