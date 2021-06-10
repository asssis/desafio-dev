FROM  mcr.microsoft.com/dotnet/sdk

EXPOSE 5000

EXPOSE 5001

WORKDIR /app

COPY . . 

RUN dotnet build -c Release

ENTRYPOINT ["dotnet", "run"]
