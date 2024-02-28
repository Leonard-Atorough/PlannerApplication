using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannerApplication.Core.Entities.EventAggregate
{
    public class EventTime //Value Object
    {
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public EventTime(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

#pragma warning disable //required by EF Core
        private EventTime(){ }
    }
}
