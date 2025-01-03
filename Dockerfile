# docker build --tag blazorunicode -f Dockerfile .
# docker run --rm --name blazorunicode -p 8080:8080 blazorunicode
#
FROM mcr.microsoft.com/dotnet/sdk:9.0-bookworm-slim AS build
WORKDIR /src
COPY /src .
WORKDIR "/src/BlazorUnicodeServer"
RUN dotnet publish "BlazorUnicodeServer.csproj" -c Release -o /app/publish 

FROM mcr.microsoft.com/dotnet/aspnet:9.0-bookworm-slim AS final
WORKDIR /app
EXPOSE 8080
COPY --from=build /app/publish .
ENTRYPOINT ["./BlazorUnicodeServer"]
