#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Transaction/Transaction.csproj", "Transaction/"]
#COPY ["StockTraderProvider/StockTraderBroker.csproj", "StockTraderProvider/"]
#COPY ["Users/Users.csproj", "Users/"]
RUN dotnet restore "Transaction/Transaction.csproj"
COPY . .
WORKDIR "/src/Transaction"
RUN dotnet build "Transaction.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Transaction.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Transaction.dll"]