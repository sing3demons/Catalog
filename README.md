# Catalog


docker run -d --rm --name mongo-dotnet -p 27017:27017 -v mongodbdata:/data/db -e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=Pass#w0rd1 mongo
dotnet user-secrets init
dotnet user-secrets set MongoDbSettings:Password Pass#w0rd1


dotnet add package AspNetCore.HealthChecks.MongoDb

# Add Docker file
- ctrl + shift + p 
> docker : Add Docker Compose Files to workspace... :  <.dotnet>

# build docker images
```
docker build -t catalog:v1 .
```

# create network
```
docker network create net5tutorial
```
```
docker network ls
```

# --network=net5tutorial
```
docker run -d --rm --name mongo-dotnet -p 27017:27017 -v mongodbdata:/data/db -e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=Pass#w0rd1 --network=net5tutorial mongo
```
# appsettings.json -> "MongoDbSettings:Host --name mongo-dotnet"
```
docker run -it --rm -p 8080:80 -e MongoDbSettings:Host=mongo-dotnet -e MongoDbSettings:Password=Pass#w0rd1 --network=net5tutorial catalog:v1
```
  # push docker hub 
   docker login
   docker images
   docker tag catalog:v1 sing3demons/catalog:v1
   docker push sing3demons/catalog:v1
   <!-- success -->

docker rmi sing3demons/catalog:v1
docker rmi catalog:v1  

docker logout

# docker push sing3demons/catalog:tagname
```
docker run -it --rm -p 8080:80 -e MongoDbSettings:Host=mongo-dotnet -e MongoDbSettings:Password=Pass#w0rd1 --network=net5tutorial sing3demons/catalog:v1
```

