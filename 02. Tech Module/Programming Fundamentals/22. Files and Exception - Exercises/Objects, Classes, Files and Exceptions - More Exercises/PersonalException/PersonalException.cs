using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PersonalException
{
    class PersonalException
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    decimal number = decimal.Parse(Console.ReadLine());
                    if (number < 0)
                    {
                        throw new MyException("My first exception is awesome!!!");
                    }
                    Console.WriteLine(number);
                }
                catch (MyException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
                
            }
        }
    }
    class MyException : Exception
    {
        public MyException() : base()
        {

        }

        public MyException(string message) : base(message)
        {

        }

        public MyException(string message, Exception innerException ) : base(message, innerException)
        {

        }

        protected MyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
