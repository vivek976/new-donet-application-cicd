# Use the ASP.NET Core runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80
ENV DOTNET_GENERATE_ASPNET_CERTIFICATES=false

USER app

# Use the .NET SDK image for building the application
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["dotnetfordocker.csproj", "./"]
RUN dotnet restore "dotnetfordocker.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "dotnetfordocker.csproj" -c $configuration -o /app/build

# Publish the application
FROM build AS publish
ARG configuration=Release
RUN dotnet publish "dotnetfordocker.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

# Final stage: copy the published app to the runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dotnetfordocker.dll"]
