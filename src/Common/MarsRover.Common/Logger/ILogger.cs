namespace MarsRover.Common.Logger
{
    public interface ILogger
    {
        public void writeErrorLog(string errorMessage);
        public void writeSuccessLog(string successMessage);
        public void writeSeperator();
        public void writeLog(string warningMessage);
    }
}
