using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTaskSystem.Tasks.Dtos
{
    public class GetTasksInput
    {
        public TaskState? State { get; set; }

        public int? AssignedPersonId { get; set; }
    }
}
