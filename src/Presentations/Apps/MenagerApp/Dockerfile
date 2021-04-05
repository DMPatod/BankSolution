#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/Presentations/Apps/MenagerApp/MenagerApp.csproj", "src/Presentations/Apps/MenagerApp/"]
COPY ["src/Infrastructures/CashierManagement/CashierManagementInfractureLayer.csproj", "src/Infrastructures/CashierManagement/"]
COPY ["src/Domains/BankManagement/CashierManagement.csproj", "src/Domains/BankManagement/"]
COPY ["src/Applications/CashierManagement/CashierManagementApplicationLayer.csproj", "src/Applications/CashierManagement/"]
RUN dotnet restore "src/Presentations/Apps/MenagerApp/MenagerApp.csproj"
COPY . .
WORKDIR "/src/src/Presentations/Apps/MenagerApp"
RUN dotnet build "MenagerApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MenagerApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MenagerApp.dll"]
