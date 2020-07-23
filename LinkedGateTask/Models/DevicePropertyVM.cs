﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedGateTask.Models
{
    public class DevicePropertyVM
    {
        public int Id { get; set; }
        public string DeviceProperty { get; set; }
        public Nullable<int> DeviceId { get; set; }

        public virtual DeviceVM Device { get; set; }
    }
}