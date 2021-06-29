# Catalog


docker run -d --rm --name mongo-dotnet -p 27017:27017 -v mongodbdata:/data/db -e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=Pass#w0rd1 mongo
dotnet user-secrets init
dotnet user-secrets set MongoDbSettings:Password Pass#w0rd1


dotnet add package AspNetCore.HealthChecks.MongoDb

  <!-- "Password": "Pass#w0rd1" -->