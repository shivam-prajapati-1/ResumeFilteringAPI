FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Project folder copy karo
COPY ResumeFilteringAPI/*.csproj ./ResumeFilteringAPI/
WORKDIR /app/ResumeFilteringAPI

RUN dotnet restore

COPY ResumeFilteringAPI/. ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/ResumeFilteringAPI/out .

EXPOSE 80
ENTRYPOINT ["dotnet", "ResumeFilteringAPI.dll"]
