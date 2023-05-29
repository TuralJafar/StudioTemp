﻿namespace StudioTemp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string LinkEdin { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
