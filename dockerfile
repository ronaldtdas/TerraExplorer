# Use the official .NET SDK image as a parent image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory in the container
WORKDIR /app

# Copy the solution file and restore any dependencies
COPY TerraExplorer.sln .
COPY TerraExplorerProject/TerraExplorerProject.csproj ./TerraExplorerProject/

# Restore dependencies
RUN dotnet restore TerraExplorerProject/TerraExplorerProject.csproj

# Copy the rest of the source code
COPY . .

# Build the application (you can adjust the configuration as needed)
RUN dotnet publish -c Release -o out -p:PublishWithAspNetCoreTargetManifest=false

# Create a runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "TerraExplorerProject.dll"]
