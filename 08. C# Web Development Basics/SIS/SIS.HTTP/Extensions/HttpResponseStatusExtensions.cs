using SIS.HTTP.Enums;
using System;

namespace SIS.HTTP.Extensions
{
    public static class HttpResponseStatusExtensions
    {
        public static string GetResponseLine(this HttpResponseStatusCode code)
        {
            return $"{(int)code} {Enum.GetName(typeof(HttpResponseStatusCode), code)}";
        }
    }
}