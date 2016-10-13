using Abp.Application.Services;
using SimpleTaskSystem.Tasks.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTaskSystem.Tasks
{
    interface ITaskAppService: IApplicationService
    {
        GetTasksOutput GetTasks(GetTasksInput input);
        void UpdateTask(UpdateTaskInput input);
        void CreateTask(CreateTaskInput input);
    }
}
