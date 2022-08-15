#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/sdk:6.0 AS build-env
WORKDIR /src
COPY ["PagesSample/PagesSample.csproj", "PagesSample/"]
RUN dotnet restore "PagesSample/PagesSample.csproj"
COPY . .
WORKDIR "/src/PagesSample"
RUN dotnet build "PagesSample.csproj" -c Release -o /app/build
RUN dotnet publish "PagesSample.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY --from=build-env /app/publish .
ENTRYPOINT ["dotnet", "PagesSample.dll"]