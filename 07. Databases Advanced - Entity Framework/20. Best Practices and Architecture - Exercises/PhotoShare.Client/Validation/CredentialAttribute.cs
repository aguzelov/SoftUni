using System;

namespace PhotoShare.Client.Validation
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class CredentialAttribute : Attribute
    {
        private bool needToBeLogin;

        public CredentialAttribute(bool needToBeLogin)
        {
            this.needToBeLogin = needToBeLogin;

            if (needToBeLogin)
            {
                if (Session.User == null)
                    throw new InvalidOperationException("Invalid Credentials!");
            }
            else
            {
                if (Session.User != null)
                    throw new InvalidOperationException("Invalid Credentials!");
            }
        }
    }
}