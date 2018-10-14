﻿namespace SIS.Framework.Attributes.Methods
{
    public class HttpGetAttribute : HttpMethodAttribute
    {
        public override bool IsValid(string requestMethod)
        {
            return requestMethod.ToUpper() == "GET" ? true : false;
        }
    }
}