using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObject
{
    public class LastStatus
    {
        public LastStatus(Status newstatus) 
        {
            Status = newstatus;
            Date = DateTime.Now;
        }
        public DateTime Date { get; set; }
        public Status Status { get; set; }
    }
    public enum Status
    {
        Enabled,
        DisabledByAdmin
    }
}
