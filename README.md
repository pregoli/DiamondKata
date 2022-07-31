# DiamondKata
Kata is based on a post by Seb Rose here: http://claysnow.co.uk/recycling-tests-in-tdd/

## Pre-requirements

In order to build and run the application the following are some pre-requirements:

- [.Net 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) installed in the hosting machine in order to be able to build and run the application from your favourite IDE.
- [Docker](https://docs.docker.com/get-docker/) installed in order to be able to run the application from container.

## Run the Diamond application
There are 3 options to run the application:
- From Command-line
- From IDE
- From Docker

1. ### Run from IDE

In order to run the application from your favourite IDE, the [Diamond.Application](https://github.com/pregoli/DiamondKata/tree/master/App/Diamond.Application) needs to be set as default starting project, then `F5`.
The application accepts a character as argument. If no arguments passed, it will pass the 'z' by default.
 
2. ### Run from Command-line

Open the command-line from the bin folder as `Diamond\App\Diamond.Application\bin\Debug\net6.0>` and execute the diamond application:

 ```console
Diamond\App\Diamond.Application\bin\Debug\net6.0>Diamond.Application.exe x
```

The above command will run your diamond application, passing the character 'x' as argument. You can play running the command with any alphabet letter as argument.
 
3. ### Run from Docker

In order to run the application from Docker, these are the steps to follow:
- Move to the main root where the `Solution` file is placed.
- Run the command: 
 
 ```console
docker build -t diamond -f App/Diamond.Application/Dockerfile .
```
It should take some seconds to pull all the dependencies and then:

 ```console
docker run -ti --rm diamond x
```

The above command will run your diamond application in interactive mode, passing the character 'x' as argument. You can play running the command with any alphabet letter as argument.
