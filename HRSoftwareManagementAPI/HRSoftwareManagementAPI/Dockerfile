FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 7180

ENV ASPNETCORE_URLS = http://+:7180

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HRSoftwareManagementAPI/HRSoftwareManagementAPI.csproj", "HRSoftwareManagementAPI/"]
RUN dotnet restore "HRSoftwareManagementAPI/HRSoftwareManagementAPI.csproj"
COPY . .
WORKDIR "/src/HRSoftwareManagementAPI"
RUN dotnet build "HRSoftwareManagementAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HRSoftwareManagementAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HRSoftwareManagementAPI.dll"]
