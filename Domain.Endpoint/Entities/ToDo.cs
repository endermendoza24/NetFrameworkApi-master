using System;

namespace Domain.Endpoint.Entities
{
    public enum ToDoStatus
    {
        Done,
        InProgress,
        Pending
    }

    public class ToDo : AuditableEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ToDoStatus Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
