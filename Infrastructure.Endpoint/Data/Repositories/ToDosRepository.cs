using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces.Repositories;
using System;
using System.Collections.Generic;

namespace Infrastructure.Endpoint.Data.Repositories
{
    public class ToDosRepository : IToDosRepository
    {
        public List<ToDo> Get()
        {
            Guid userId = Guid.NewGuid();
            ToDo todo001 = new ToDo()
            {
                Id = Guid.NewGuid(),
                Title = "ToDo 001",
                Description = "Description",
                CreatedAt = DateTime.Now.AddDays(-10),
                CreatedBy = userId,
                Status = ToDoStatus.InProgress,
                StartDate = DateTime.Now.AddDays(-5),
                UpdatedAt = DateTime.Now.AddDays(-5),
                UpdatedBy = userId,
            };
            
            ToDo todo002 = new ToDo()
            {
                Id = Guid.NewGuid(),
                Title = "ToDo 002",
                Description = "Description",
                CreatedAt = DateTime.Now.AddDays(-20),
                CreatedBy = userId,
                Status = ToDoStatus.Pending,
            };

            return new List<ToDo> { todo001, todo002 };
        }
    }
}
