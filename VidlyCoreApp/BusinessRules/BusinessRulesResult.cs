using System;

namespace VidlyCoreApp.BusinessRules
{
    public class BusinessRulesResult
    {
        public BusinessRulesResult()
        {
            IsErrored = false;
        }

        public string ErrorMessage { get; set; }
        public bool IsErrored { get; set; }
    }
}
