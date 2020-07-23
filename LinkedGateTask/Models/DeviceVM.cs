using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedGateTask.Models
{
    public class DeviceVM
    {
        public int Id { get; set; }
        public string DeviceName { get; set; }
        public string SerialNo { get; set; }
        public string Memo { get; set; }
    }
}