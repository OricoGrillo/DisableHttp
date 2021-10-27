FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["src/cart-api-gcp.csproj", "src/"]
RUN dotnet restore "src/cart-api-gcp.csproj"
COPY . .
WORKDIR "/src/src"
RUN dotnet build "cart-api-gcp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "cart-api-gcp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "cart-api-gcp.dll"]
