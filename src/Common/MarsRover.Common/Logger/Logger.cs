using System;

namespace MarsRover.Common.Logger
{
    public class Logger: ILogger
    {
        public void writeErrorLog(string errorMessage)
        {
            Console.WriteLine("Hata : " + errorMessage);
        }

        public void writeSuccessLog(string successMessage)
        {
            Console.WriteLine("Başarılı : " + successMessage);
        }

        public void writeSeperator()
        {
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
        }

        public void writeLog(string warningMessage)
        {
            Console.WriteLine(warningMessage);
        }
    }
}
