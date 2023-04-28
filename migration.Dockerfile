FROM mcr.microsoft.com/dotnet/sdk:7.0

ENV ASPNETCORE_ENVIRONMENT="Development"

ENV EF_VERSION="7.0.5"

WORKDIR /app

RUN dotnet tool install -g dotnet-ef --version $EF_VERSION

ENV PATH $PATH:/root/.dotnet/tools

CMD dotnet ef database update
