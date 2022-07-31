FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
COPY . /src

WORKDIR /src

RUN dotnet publish -c Release -o /app App/Diamond.Application/Diamond.Application.csproj

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS runtime
COPY --from=build /app /app
WORKDIR /app

ENTRYPOINT ["dotnet", "Diamond.Application.dll"]