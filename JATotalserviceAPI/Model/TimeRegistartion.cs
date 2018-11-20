using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer
{
    public class TimeRegistartion
    {
        public int Id { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public Task task { get; set; }
        public Employee employee { get; set; }
    }
}
