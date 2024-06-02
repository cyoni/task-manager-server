using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{

    public enum E_LogLevel
    {
        Warning = 0,
        Low = 1,
        Medium = 2, 
        High = 3,
        Critical = 4
    }

    public enum E_TaskType
    {
        AllTasks = 0,
        ToDo = 1,
        Completed = 2,
        InProgress = 3,

    }
}
