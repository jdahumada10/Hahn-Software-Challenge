# .NET Core Runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

# Expose ports
EXPOSE 80

# .NET Core SDK
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Sets the working directory
WORKDIR /src
# Copy EntryPoint
COPY ["EntryPoint/EntryPoint.csproj", "./EntryPoint/"]
# Copy Core
COPY ["Core/Core.csproj", "./Core/"]
# Copy DataProvider
COPY ["DataProvider/DataProvider.csproj", "./DataProvider/"]
# Copy Main
COPY ["HRSoftwareManagementAPI/HRSoftwareManagementAPI.csproj", "HRSoftwareManagementAPI/"]
# .NET Core Restore
RUN dotnet restore "HRSoftwareManagementAPI/HRSoftwareManagementAPI.csproj"
COPY . .

# Sets the working directory
WORKDIR "/src/HRSoftwareManagementAPI"

# .NET Core Build and Publish
RUN dotnet build "HRSoftwareManagementAPI.csproj" -c Release -o /app
FROM build AS publish
RUN dotnet publish "HRSoftwareManagementAPI.csproj" -c Release -o /app

# ASP.NET Core Runtime
FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "HRSoftwareManagementAPI.dll"]

ENV ASPNETCORE_URLS=http://+:5005