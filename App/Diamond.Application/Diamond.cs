using System.Text;

namespace Diamond.Application;

public class Diamond
{
    public static readonly char[] AlphabetLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    private static readonly char FirstAlphabetLetter = AlphabetLetters.First();

    private readonly int inputIndex;
    private readonly StringBuilder diamondBuilder;

    private Diamond(char input)
    {
        diamondBuilder = new StringBuilder();
        inputIndex = Array.FindIndex(AlphabetLetters, letter => letter == char.ToUpper(input));
        PrintLine(inputIndex, FirstAlphabetLetter);
    }

    internal bool InputIsEqualToFirstAlphabetLetter => inputIndex is 0;
    public string Output => diamondBuilder.ToString();

    public static Diamond InitializeWithInput(char input)
    {
        return new Diamond(input);
    }

    public Diamond Build()
    {
        if (InputIsEqualToFirstAlphabetLetter)
            return this;

        for (int nextCharIndex = 1; nextCharIndex <= inputIndex; nextCharIndex++)
            PrintLine(inputIndex - nextCharIndex, AlphabetLetters[nextCharIndex], nextCharIndex + (nextCharIndex - 1));

        for (int nextCharIndex = inputIndex - 1; nextCharIndex >= 0; nextCharIndex--)
            PrintLine(inputIndex - nextCharIndex, AlphabetLetters[nextCharIndex], nextCharIndex + (nextCharIndex - 1));

        return this;
    }

    private void PrintLine(int paddingLeft, char @char, int paddingRight = 0)
    {
        const char PaddingUnitSpace = ' ';

        diamondBuilder.Append($"{string.Empty.PadLeft(paddingLeft, PaddingUnitSpace)}{@char}");

        if (@char != FirstAlphabetLetter)
            diamondBuilder.Append($"{string.Empty.PadLeft(paddingRight, PaddingUnitSpace)}{@char}");

        diamondBuilder.Append('\n');
    }
}