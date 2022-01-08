using System;
using System.Collections.Generic;
using Tasks.Domain.Abstarct;

namespace Tasks.Domain.Entities
{
    public class Task : Entity
    {
        public string Name { get; set; }
        public List<Mission> Missions { get; set; }
        public DateTime Created{ get; set; }
    }
}
