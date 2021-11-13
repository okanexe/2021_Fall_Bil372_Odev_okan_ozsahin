using System.Text.RegularExpressions;

namespace WinTicket.Util
{
    public class PasswordValidator
    {
        public static bool Validate(string password)
        {
            var regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[.:;!?]).{8,15}$");
            if (regex.IsMatch(password))
            {
                return true;
            }

            return false;
        }
    }
}
