# Stage 1: Base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV DOTNET_GENERATE_ASPNET_CERTIFICATES=false

# Stage 2: Build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src 
COPY ["dotnetfordocker.csproj", "./"]
RUN dotnet restore "dotnetfordocker.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "dotnetfordocker.csproj" -c $configuration -o /app/build

# Stage 3: Publish image
FROM build AS publish
ARG configuration=Release 
RUN dotnet publish "dotnetfordocker.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

# Stage 4: Final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dotnetfordocker.dll"]
