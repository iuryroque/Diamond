namespace diamond
{
  public class Program
  {
    public static void Main(string [] args)
    {
      int character_position;

      Console.WriteLine("Imprime Diamante");
      Console.WriteLine("-----------------------------------");

      character_position = Diamond.GetCharacter();
      string textDiamond = Diamond.CreateDiamond(character_position);
      Console.WriteLine(textDiamond);
      
      if (Email.QuestionEmail())
      {
        Console.Write(Email.SendMail(textDiamond));
      }

    }
  }
}
