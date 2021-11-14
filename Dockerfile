#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/aspnet:6.0.0-focal-amd64 AS base
FROM mcr.microsoft.com/dotnet/aspnet:6.0.0-alpine3.14-amd64 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0.100-alpine3.14-amd64 AS build
WORKDIR /src
COPY ["src/BlazorUnicodeServer/BlazorUnicodeServer.csproj", "src/BlazorUnicodeServer/"]
COPY ["src/BlazorUnicode/BlazorUnicode.csproj", "src/BlazorUnicode/"]
RUN dotnet restore "src/BlazorUnicodeServer/BlazorUnicodeServer.csproj"
COPY . .
WORKDIR "/src/src/BlazorUnicodeServer"
RUN dotnet build "BlazorUnicodeServer.csproj" -r linux-musl-x64 -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorUnicodeServer.csproj" -r linux-musl-x64 -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["./BlazorUnicodeServer"]
