using System.Globalization;

namespace ECommerce.API.Helpers
{
    public class AppException : Exception
    {
        public AppException() : base() { }

        public AppException(string message) : base(message) { }

        public AppException(string message, params object[] agrs)
            : base(String.Format(CultureInfo.CurrentCulture, message, agrs)) { }
    }
}
