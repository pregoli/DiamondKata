using System.Text;

namespace Diamond.Application;

public class Diamond
{
    private Diamond(char input)
    {
        InputIndex = Array.FindIndex(chars, letter => letter == char.ToUpper(input));
        PrintLine(InputIndex, firstChar);
    }

    private static readonly char[] chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    private static readonly char firstChar = chars.First();
    private const char PaddingUnitSpace = ' ';
    
    private readonly StringBuilder diamondBuilder = new();
    
    internal static char Input { get; private set; }
    internal int InputIndex { get; private set; } = Array.FindIndex(chars, letter => letter == char.ToUpper(Input));
    internal static bool InputIsEqualToFirstChar => Input == firstChar;
    internal int ReverseInputIndex => InputIndex - 1;
    
    public string Output => diamondBuilder.ToString();

    public static Diamond InitializeWithInput(char input)
    {
        return new Diamond(input);
    }

    public string Build()
    {
        if (InputIsEqualToFirstChar)
            return Output;

        for (int nextCharIndex = 1; nextCharIndex <= InputIndex; nextCharIndex++)
            PrintLine(InputIndex - nextCharIndex, chars[nextCharIndex], nextCharIndex + (nextCharIndex - 1));

        for (int nextCharIndex = ReverseInputIndex; nextCharIndex >= 0; nextCharIndex--)
            PrintLine(InputIndex - nextCharIndex, chars[nextCharIndex], nextCharIndex + (nextCharIndex - 1));

        return Output;
    }

    private void PrintLine(int paddingLeft, char @char, int paddingRight = 0)
    {
        diamondBuilder.Append($"{string.Empty.PadLeft(paddingLeft, PaddingUnitSpace)}{@char}");

        if (@char != firstChar)
            diamondBuilder.Append($"{string.Empty.PadLeft(paddingRight, PaddingUnitSpace)}{@char}");

        diamondBuilder.Append('\n');
    }
}