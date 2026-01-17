# ================= BUILD STAGE =================
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Solution and project files copy karo
COPY ResumeFiltering.sln ./
COPY ResumeFiltering.API/ResumeFiltering.API.csproj ResumeFiltering.API/
COPY ResumeFiltering.Data/ResumeFiltering.Data.csproj ResumeFiltering.Data/

# Restore dependencies
RUN dotnet restore

# Baaki sab files copy karo
COPY . .

# API project publish karo
RUN dotnet publish ResumeFiltering.API/ResumeFiltering.API.csproj -c Release -o out

# ================= RUNTIME STAGE =================
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app

COPY --from=build /app/out .

EXPOSE 80
ENTRYPOINT ["dotnet", "ResumeFiltering.API.dll"]
