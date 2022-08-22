using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace HospitalManagement
{
    class Sqlbaglanti
    {
        public SqlConnection baglanti()
        {
            SqlConnection link = new SqlConnection("Data Source=DESKTOP-2POAH45; Initial Catalog=HastaneManage; Integrated Security=True");
            link.Open();
            return link;
        }
    }
}
