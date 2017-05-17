using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niall_Firmstep.Models
{
    public class QueueItemContext: DbContext
    {
        public DbSet<QueueItem> QueueItems { get; set; }
        
    }
}
