namespace MarsRover.Common.Validation
{
    public class ValidationHelper
    {
        public static bool StringIsNullOrEmpty(string strVal)
        {
            if (string.IsNullOrWhiteSpace(strVal))
                return true;
            else
                return false;
        }
    }
}
