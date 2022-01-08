using System;
using Tasks.Domain.Abstarct;

namespace Tasks.Domain.Entities
{
    public class Mission : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public Guid TaskId{ get; set; }
        public Task Task { get; set; }
    }
}
