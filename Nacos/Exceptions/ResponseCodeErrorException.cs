using System;

namespace Com.Alibaba.Nacos.Exceptions
{
    public class ResponseCodeErrorException : Exception
    {
        public ResponseCodeErrorException(int code, string message) : base(message)
        {
            HResult = code;
        }
    }
}