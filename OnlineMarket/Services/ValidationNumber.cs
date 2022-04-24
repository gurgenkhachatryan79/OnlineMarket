using System;

namespace OnlineMarket.Services
{
    public class ValidationNumber
    {
        public static bool ProductExists(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            return true;
        }
    }
}
