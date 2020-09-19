#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MS.Customer.Api/MS.Customer.Api.csproj", "MS.Customer.Api/"]
COPY ["MS.Customer.Application/MS.Customer.Application.csproj", "MS.Customer.Application/"]
COPY ["MS.Customer.Application.Abstraction/MS.Customer.Application.Abstraction.csproj", "MS.Customer.Application.Abstraction/"]
COPY ["MS.Customer.Domain/MS.Customer.Domain.csproj", "MS.Customer.Domain/"]
COPY ["MS.Customer.Infastructure/MS.Customer.Infastructure.csproj", "MS.Customer.Infastructure/"]
COPY ["MS.Customer.Persistence/MS.Customer.Persistence.csproj", "MS.Customer.Persistence/"]
RUN dotnet restore "MS.Customer.Api/MS.Customer.Api.csproj"
COPY . .
WORKDIR "/src/MS.Customer.Api"
RUN dotnet build "MS.Customer.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MS.Customer.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MS.Customer.Api.dll"]