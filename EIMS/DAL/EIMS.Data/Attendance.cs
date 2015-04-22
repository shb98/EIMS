using System;

namespace EIMS.Data
{
    public class VacationRequest
    {
        public int VacationRequestId { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset EndDate { get; set; }

        public string Reason { get; set; }

        public string Comments { get; set; }

        public virtual Employee RequestedBy { get; set; }

        public virtual Employee ApprovedBy { get; set; }
    }
}