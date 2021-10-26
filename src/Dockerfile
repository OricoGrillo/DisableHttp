FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
WORKDIR /app
EXPOSE 80

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["cart-api-gcp.csproj", "src/"]
RUN dotnet restore "cart-api-gcp.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "cart-api-gcp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "cart-api-gcp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "cart-api-gcp.dll"]
