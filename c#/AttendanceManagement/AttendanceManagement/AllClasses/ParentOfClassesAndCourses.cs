﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceManagement.AllClasses
{
    public class ParentOfClassesAndCourses
    {
        public int ID { get;  set; }
        public string Name { get;  set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
