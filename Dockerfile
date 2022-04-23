FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /App

COPY . ./

RUN dotnet publish -c Release

# ENV PATH $PATH:/root/.dotnet/tools
# RUN dotnet tool install -g dotnet-ef

CMD ASPNETCORE_URLS=http://*:$PORT dotnet bin/Release/net5.0/facture.dll