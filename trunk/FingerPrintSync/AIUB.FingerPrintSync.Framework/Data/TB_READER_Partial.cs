

using System;
using System.Runtime.Serialization;

namespace AIUB.FingerPrintSync.Framework.Data
{
    public partial class TB_READER
    {
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public bool Status { get; set; }
        public enum ReaderStatusEnum
        {
            Offline = 0,
            Online = 1
           
        }
        [DataMember]
        public ReaderStatusEnum Status2
        {
            get
            {
                return (ReaderStatusEnum)Convert.ToInt16(this.Status);
            }
            set
            {
                int a = (int) value;
                this.Status = Convert.ToBoolean(a);
            }
        }

       
    }
}
