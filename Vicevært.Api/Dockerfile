#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Vicevært.Api/Vicevært.Api.csproj", "Vicevært.Api/"]
COPY ["Vicevært.Infrastructure/Vicevært.Infrastructure.csproj", "Vicevært.Infrastructure/"]
COPY ["Vicevært.Domain/Vicevært.Domain.csproj", "Vicevært.Domain/"]
COPY ["Vicevært.Application/Vicevært.Application.csproj", "Vicevært.Application/"]
COPY ["Vicevært.Contract/Vicevært.Contract.csproj", "Vicevært.Contract/"]
RUN dotnet restore "Vicevært.Api/Vicevært.Api.csproj"
COPY . .
WORKDIR "/src/Vicevært.Api"
RUN dotnet build "Vicevært.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Vicevært.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Vicevært.Api.dll"]