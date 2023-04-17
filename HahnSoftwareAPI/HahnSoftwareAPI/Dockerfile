FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HahnSoftwareAPI/HahnSoftwareAPI.csproj", "HahnSoftwareAPI/"]
RUN dotnet restore "HahnSoftwareAPI/HahnSoftwareAPI.csproj"
COPY . .
WORKDIR "/src/HahnSoftwareAPI"
RUN dotnet build "HahnSoftwareAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HahnSoftwareAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HahnSoftwareAPI.dll"]
