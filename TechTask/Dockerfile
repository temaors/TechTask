FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TechTask/TechTask.csproj", "TechTask/"]
RUN dotnet restore "TechTask/TechTask.csproj"
COPY . .
WORKDIR "/src/TechTask"
RUN dotnet build "TechTask.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TechTask.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TechTask.dll"]
