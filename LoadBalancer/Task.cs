using System;
using System.Collections.Generic;

namespace LoadBalancer
{
    public class Task
    {
        public int Id {
            get;
            set;
        }
        public DateTime Time
        {
            get;
            set;
        }
        public string Command
        {
            get;
            set;
        }

        public string[] Arguments
        {
            get;
            set;
        }

        public object Result
        {
            get;
            set;
        }

    }
    public class TaskComparer : IComparer<Task>
    {
        public int Compare(Task x, Task y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (ReferenceEquals(null, y)) return 1;
            if (ReferenceEquals(null, x)) return -1;
            var timeComparison = x.Time.CompareTo(y.Time);
            if (timeComparison != 0) return timeComparison;
            return x.Id.CompareTo(y.Id);
        }
    }

}