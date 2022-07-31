var input = !args.Any() ? 'z' : char.Parse(args[0]);

var diamond = Diamond.Application.Diamond
    .InitializeWithInput(input)
    .Build();

Console.WriteLine(diamond.Output);
Console.ReadLine();
