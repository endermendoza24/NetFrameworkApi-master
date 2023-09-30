using Domain.Endpoint.Entities;
using System.Collections.Generic;

namespace Domain.Endpoint.Interfaces.Services
{
    public interface IToDosService
    {
        List<ToDo> GetAll();
    }
}
