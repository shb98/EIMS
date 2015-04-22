using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIMS.Data
{
    public class EmployeeMovement
    {
        public int EmployeeMovementId { get; set; }

        public DateTimeOffset MovementDate { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Department OldDepartment { get; set; }

        public virtual Department NewDepartment { get; set; }
    }
}
