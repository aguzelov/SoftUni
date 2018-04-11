using System;
using System.Collections.Generic;
using System.Text;
using Twitter.Contracts;

namespace Twitter.Models
{
    public class Tweet : ITweet
    {
        private string message;

        public Tweet()
        {
        }

        public string Message
        {
            get => message;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Message can`t be null!");
                }

                message = value;
            }
        }
    }
}