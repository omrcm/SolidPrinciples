FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SolidPrinciples/SolidPrinciples.csproj", "SolidPrinciples/"]
RUN dotnet restore "SolidPrinciples/SolidPrinciples.csproj"
COPY . .
WORKDIR "/src/SolidPrinciples"
RUN dotnet build "SolidPrinciples.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SolidPrinciples.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SolidPrinciples.dll"]
