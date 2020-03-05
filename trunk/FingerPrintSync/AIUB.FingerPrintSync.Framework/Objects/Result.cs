using System;
using System.Collections.Generic;

namespace AIUB.FingerPrintSync.Framework.Objects
{
    public class Result
    {
        private List<string> _messages = new List<string>();

        public List<String> Messages
        {
            get { return _messages; }
            set { _messages = value; }
        }

        public bool HasError { get; set; }
    }

    public class Result<T> : Result
    {
        public T Data { get; set; }
    }
}