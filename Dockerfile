# Use a imagem base do SDK .NET para construir o aplicativo
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Define o diretório de trabalho dentro do contêiner
WORKDIR /app

# Copia o arquivo .csproj e restaura as dependências
COPY *.csproj ./
RUN dotnet restore

# Copia o restante do código-fonte
COPY . ./

# Compila o aplicativo
RUN dotnet publish -c Release -o out

# Use a imagem base do runtime .NET para executar o aplicativo
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS runtime

WORKDIR /app

COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "Comex_Library.dll"]
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS runtime

WORKDIR /app

COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "Comex_Library.dll"]