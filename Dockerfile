# Use the official .NET SDK image as the build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy the solution file and restore NuGet packages
COPY QuantoEra.sln ./
COPY QuantoEra.Web/QuantoEra.Web.csproj QuantoEra.Web/
COPY QuantoEra.Calendar/QuantoEra.Calendar.csproj QuantoEra.Calendar/
COPY QuantoEra.IPCA/QuantoEra.IPCA.csproj QuantoEra.IPCA/
RUN dotnet restore QuantoEra.Web/QuantoEra.Web.csproj

# Copy the remaining source code and build the project
COPY . .
WORKDIR /src/QuantoEra.Web
RUN dotnet build "QuantoEra.Web.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "QuantoEra.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Use the official ASP.NET runtime image as the final stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Expose the port
EXPOSE 8080

# Set the entry point to run the application
ENTRYPOINT ["dotnet", "QuantoEra.Web.dll"]
