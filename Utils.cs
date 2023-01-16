using System.Text.RegularExpressions;

namespace diamond
{
  public class Utils
  {
    public static int TransformLetterInNumber(char character)
    {
      return (int)character %32;
    }
    public static char TransformNumberInLetter(int number)
    {
        int asciiValue = number + 65;
        return (char)asciiValue;
    }
    public static bool CheckIsValidEmail(string email)
    {
        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Match match = regex.Match(email);
        return match.Success;
    }
  }
}
