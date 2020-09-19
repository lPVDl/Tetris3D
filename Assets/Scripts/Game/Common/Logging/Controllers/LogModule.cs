using UnityEngine;

namespace Game.Common.Logging       
{
    public class LogModule
    {
        public const string EnableLogInfoDefine = "PINGLE_ENABLE_LOG_INFO";
        public const string EnableLogErrorDefine = "PINGLE_ENABLE_LOG_ERROR";
        public const string EnableLogWarningDefine = "PINGLE_ENABLE_LOG_WARNING";
        public const string EnableLogAssertDefine = "PINGLE_ENABLE_LOG_ASSERT";
        public const string EnableLogExceptionDefine = "PINGLE_ENABLE_LOG_EXCEPTION";

        private readonly string _messageHeader;

        public LogModule(string messageHeader)
        {
            _messageHeader = messageHeader;
        }

        [System.Diagnostics.Conditional(EnableLogInfoDefine)]
        public void Info(string message)
        {
            Debug.Log(_messageHeader + message);
        }
    }
}
