using System;
using System.Collections.Generic;

namespace AIUB.FingerPrintSync.Framework.Objects
{
    public  class LogDTO
    {
        public int id { get; set; }
        public string IpAddress { get; set; }
        public DateTime LogTime { get; set; }
        public string UserId { get; set; }
        public string PunchType { get; set; }
        public string DeviceId { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsSynced { get; set; }
        public string RoomNumber { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsInvalid { get; set; }
    }
}