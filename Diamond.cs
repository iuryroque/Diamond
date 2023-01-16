namespace diamond
{
  public class Diamond
  {
    public static int GetCharacter()
    {
      char character;
      int character_position;
      while (true)
      {
        Console.WriteLine("A menor letra possivel para o sistema é C");
        Console.Write("Digite uma unica letras do diamante: ");
        var readString = Console.ReadLine();

        // valida se não é nulo e se contem somente um caractere
        if (readString is null || readString.Length > 1) continue;

        // Transforma em caractere maiusculo
        character = Char.Parse(readString.ToUpper());

        character_position = Utils.TransformLetterInNumber(character);

        // valida se o caractere é letra e se a posição é mais que a da letra C
        if (!Char.IsLetter(character) || character_position < Constants.LETTER_C) continue;

        return character_position;
      }
    }
    public static string Spaces(int quantityLines)
    {
      string text = "";
        for (int spaces = 0; spaces < quantityLines; ++spaces)
        {
            text = " " + text;
        }
        return text;
    }
    public static string CreateDiamond(int quantityLines)
    {
      string textDiamond = "";
        // Parte superior até o meio do diamante
        for (int line = 0; line < quantityLines; ++line)
        {
            textDiamond += Diamond.Spaces((quantityLines - line) * 2);
            for (int character = 0; character <= line * 2; ++character)
            {
              
                if (character == 0 || character == line * 2)
                {
                    textDiamond += Utils.TransformNumberInLetter(line) + Diamond.Spaces(1);
                }
                else
                {
                    textDiamond += Diamond.Spaces(2);
                }
            }
           textDiamond += "\n";
        }

        // Parte após o meio
        for (int line = 2; line <= quantityLines; ++line)
        {
            textDiamond += Diamond.Spaces(line * 2);
            for (int character = 0; character <= (quantityLines - line) * 2; ++character)
            {
                if (character == 0 || character == (quantityLines - line) * 2)
                {
                    textDiamond += Utils.TransformNumberInLetter(quantityLines-line) + Diamond.Spaces(1);
                }
                else
                {
                    textDiamond += Diamond.Spaces(2);
                }
            }
            textDiamond += "\n";
        }
      return textDiamond;
    }
  }
}
