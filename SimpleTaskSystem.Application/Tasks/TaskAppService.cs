using Abp.Application.Services;
using Abp.Domain.Repositories;
using SimpleTaskSystem.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleTaskSystem.Tasks.Dtos;
using AutoMapper;

namespace SimpleTaskSystem.Tasks
{
    public class TaskAppService:ApplicationService,ITaskAppService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IRepository<Person> _personRepository;

        public TaskAppService(ITaskRepository taskRepository,IRepository<Person> personRepository)
        {
            _taskRepository = taskRepository;
            _personRepository = personRepository;
        }

        public GetTasksOutput GetTasks(GetTasksInput input)
        {
            //Called specific GetAllWithPeople method of task repository.
            var tasks = _taskRepository.GetAllWithPeople(input.AssignedPersonId, input.State);

            //Used AutoMapper to automatically convert List<Task> to List<TaskDto>.
            return new GetTasksOutput
            {
                Tasks = Mapper.Map<List<TaskDto>>(tasks)
            };
        }

        public void UpdateTask(UpdateTaskInput input)
        {
            //We can use Logger, it's defined in ApplicationService base class.
            Logger.Info("Updating a task for input: " + input);

            //Retrieving a task entity with given id using standard Get method of repositories.
            var task = _taskRepository.Get(input.TaskId);

            //Updating changed properties of the retrieved task entity.

            if (input.State.HasValue)
            {
                task.State = input.State.Value;
            }

            if (input.AssignedPersonId.HasValue)
            {
                task.AssignedPerson = _personRepository.Load(input.AssignedPersonId.Value);
            }

            //We even do not call Update method of the repository.
            //Because an application service method is a 'unit of work' scope as default.
            //ABP automatically saves all changes when a 'unit of work' scope ends (without any exception).
        }

        public void CreateTask(CreateTaskInput input)
        {
            //We can use Logger, it's defined in ApplicationService class.
            Logger.Info("Creating a task for input: " + input);

            //Creating a new Task entity with given input's properties
            var task = new Task { Description = input.Description };

            if (input.AssignedPersonId.HasValue)
            {
                task.AssignedPerson = _personRepository.Load(input.AssignedPersonId.Value);
            }

            //Saving entity with standard Insert method of repositories.
            _taskRepository.Insert(task);
        }
    }
}
