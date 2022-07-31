using System.Text;

namespace Diamond.Application;

public class Diamond
{
    private readonly int inputIndex;
    private readonly StringBuilder diamondBuilder;

    private Diamond(char input)
    {
        diamondBuilder = new StringBuilder();
        inputIndex = Array.FindIndex(AlphabetLetters, letter => letter == char.ToUpper(input));
        PrintLine(inputIndex, FirstAlphabetLetter);
    }

    private static readonly char[] AlphabetLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    private static readonly char FirstAlphabetLetter = AlphabetLetters.First();
    private const char PaddingUnitSpace = ' ';
    
    internal static char Input { get; private set; }
    internal static bool InputIsEqualToFirstChar => Input == FirstAlphabetLetter;
    
    public string Output => diamondBuilder.ToString();

    public static Diamond InitializeWithInput(char input)
    {
        return new Diamond(input);
    }

    public string Build()
    {
        if (InputIsEqualToFirstChar)
            return Output;

        for (int nextCharIndex = 1; nextCharIndex <= inputIndex; nextCharIndex++)
            PrintLine(inputIndex - nextCharIndex, AlphabetLetters[nextCharIndex], nextCharIndex + (nextCharIndex - 1));

        for (int nextCharIndex = inputIndex - 1; nextCharIndex >= 0; nextCharIndex--)
            PrintLine(inputIndex - nextCharIndex, AlphabetLetters[nextCharIndex], nextCharIndex + (nextCharIndex - 1));

        return Output;
    }

    private void PrintLine(int paddingLeft, char @char, int paddingRight = 0)
    {
        diamondBuilder.Append($"{string.Empty.PadLeft(paddingLeft, PaddingUnitSpace)}{@char}");

        if (@char != FirstAlphabetLetter)
            diamondBuilder.Append($"{string.Empty.PadLeft(paddingRight, PaddingUnitSpace)}{@char}");

        diamondBuilder.Append('\n');
    }
}