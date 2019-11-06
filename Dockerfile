FROM microsoft/dotnet:3.0-sdk

WORKDIR /app

COPY . .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet keepr.dll