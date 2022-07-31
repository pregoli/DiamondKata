var input = !args.Any() ? 'z' : char.Parse(args[0]);

var output = Diamond.Application.Diamond
    .InitializeWithInput(input)
    .Build();

Console.WriteLine(output);
Console.ReadLine();
