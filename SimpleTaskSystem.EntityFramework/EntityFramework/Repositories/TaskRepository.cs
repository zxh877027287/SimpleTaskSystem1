using SimpleTaskSystem.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abp.EntityFramework;
using Abp.Domain.Repositories;
using System.Linq.Expressions;
using System.Data.Entity;

namespace SimpleTaskSystem.EntityFramework.Repositories
{
    public class TaskRepository : SimpleTaskSystemRepositoryBase<Task, long>, ITaskRepository
    {
        public TaskRepository(IDbContextProvider<SimpleTaskSystemDbContext> dbContextProvider) 
            :base(dbContextProvider)
        {
        }

        public List<Task> GetAllWithPeople(int? assignedPersonId, TaskState? state)
        {
            var query = GetAll();
            if (assignedPersonId.HasValue)
            {
                query.Where(task => task.AssignedPersonId == assignedPersonId.Value);
            }
            if (state.HasValue)
            {
                query = query.Where(task => task.State == state);
            }
            return query
                .OrderByDescending(task => task.CreationTime)
                .Include(task => task.AssignedPerson)
                .ToList();
        }
    }
}
