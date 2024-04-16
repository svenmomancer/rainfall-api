FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 7170
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["rainfall.api/rainfall.api.csproj", "rainfall.api/"]
COPY ["rainfall.service/rainfall.service.csproj", "rainfall.service/"]
COPY ["rainfall.data/rainfall.data.csproj", "rainfall.data/"]
COPY ["rainfall.domain/rainfall.domain.csproj", "rainfall.domain/"]

RUN dotnet restore "rainfall.api/rainfall.api.csproj"
COPY . .
WORKDIR "/src/rainfall.api"
RUN dotnet build "rainfall.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "rainfall.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "rainfall.api.dll"]