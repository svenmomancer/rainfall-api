# rainfall api services


## Requirements
- VS code
- Visual Studio 2019 up to latest
- IIS (optional)
- Docker Desktop or WSL Docker (optional)
- .NET 6
- Powershell 7

### Build image

Go to the **rainfall.api** directory and type the command below.

```
docker build -t rainfall.api:latest .
```

### Run Image

```
docker run -p 3000:3000 -d --network heroes-network  --name rainfall.api rainfall.api:latest
```

### Run rainfall-api, mongo and redis images using docker compose file.
```
docker compose up -d
```

### You can run the app locally
```
dotnet run
```

## Notes:
 - When not using docker and just running the main.go server use **localhost** to connect to mongo db otherwise use **host.docker.internal**
 - You may see **.env** files has some values it just pointing to your local the appication will use a cloud mongo database.
