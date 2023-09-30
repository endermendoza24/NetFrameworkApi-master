using Domain.Endpoint.Entities;
using System.Collections.Generic;

namespace Domain.Endpoint.Interfaces.Repositories
{
    public interface IToDosRepository
    {
        List<ToDo> Get();
    }
}
