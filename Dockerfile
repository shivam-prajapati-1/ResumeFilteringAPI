# ========== BUILD STAGE ==========
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy solution and project files
COPY ResumeFiltering.sln ./
COPY ResumeFiltering.API/ResumeFiltering.API.csproj ResumeFiltering.API/
COPY ResumeFiltering.Data/ResumeFiltering.Data.csproj ResumeFiltering.Data/

# Restore
RUN dotnet restore

# Copy remaining files
COPY . .

# Publish API project
RUN dotnet publish ResumeFiltering.API/ResumeFiltering.API.csproj -c Release -o out

# ========== RUNTIME STAGE ==========
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/out .

EXPOSE 80
ENTRYPOINT ["dotnet", "ResumeFiltering.API.dll"]
