FROM mcr.microsoft.com/dotnet/aspnet:latest AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:latest AS build
WORKDIR /src
COPY ["LibraryExercise.API/LibraryExercise.API.csproj", "LibraryExercise.API/"]
RUN dotnet restore "LibraryExercise.API/LibraryExercise.API.csproj"
COPY . .
WORKDIR "/src/LibraryExercise.API"
RUN dotnet build "LibraryExercise.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LibraryExercise.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LibraryExercise.API.dll"]