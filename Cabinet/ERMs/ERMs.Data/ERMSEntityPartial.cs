using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMs.Data
{
    class ERMSEntityPartial
    {
    }

    public partial class ERMSEntities : DbContext
    {
        public ERMSEntities(string conn) : base(conn)
        {
        }

    }
}
