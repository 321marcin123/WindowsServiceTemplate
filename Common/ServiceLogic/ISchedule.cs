using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ServiceLogic
{
    public interface ISchedule
    {
        void ScheduleService(Type jobType);

        void StartSchedule();

    }
}
