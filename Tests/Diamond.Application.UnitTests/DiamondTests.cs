using FluentAssertions;
using NUnit.Framework;

namespace Diamond.Application.UnitTests
{
    [TestFixture]
    public class Tests
    {
        [TestCase('a')]
        [TestCase('b')]
        [TestCase('y')]
        [TestCase('z')]
        public void Given_Any_Valid_Input_Then_The_First_Output_Letter_Should_Be_A(char input)
        {
            //Arrange
            var diamond = Diamond.InitializeWithInput(input);

            //Act
            diamond.Build();

            //Assert
            diamond.Output.TrimStart().First().Should().Be('A');
        }

        [TestCase('a')]
        [TestCase('b')]
        [TestCase('y')]
        [TestCase('z')]
        public void Given_Any_Valid_Input_Then_The_Last_Output_Letter_Should_Be_A(char input)
        {
            //Arrange
            var diamond = Diamond.InitializeWithInput(input);

            //Act
            diamond.Build();

            //Assert
            diamond.Output.TrimEnd().Last().Should().Be('A');
        }

        [TestCaseSource(nameof(TestCases))]
        public void Given_the_Input_Then(char input, string expectedOutput)
        {
            //Arrange
            var diamond = Diamond.InitializeWithInput(input);

            //Act
            diamond.Build();

            //Assert
            diamond.Output.Should().Be(expectedOutput);
        }

        protected static readonly object[] TestCases = {
                new object[] { 'a', "A\n" },
                new object[] { 'b', " A\nB B\n A\n" },
                new object[] { 'c', "  A\n B B\nC   C\n B B\n  A\n" },
                new object[] { 'd', "   A\n  B B\n C   C\nD     D\n C   C\n  B B\n   A\n" },
                new object[] { 'e', "    A\n   B B\n  C   C\n D     D\nE       E\n D     D\n  C   C\n   B B\n    A\n" },
                new object[] { 'f', "     A\n    B B\n   C   C\n  D     D\n E       E\nF         F\n E       E\n  D     D\n   C   C\n    B B\n     A\n" },
                new object[] { 'g', "      A\n     B B\n    C   C\n   D     D\n  E       E\n F         F\nG           G\n F         F\n  E       E\n   D     D\n    C   C\n     B B\n      A\n" }
            };
    }
}