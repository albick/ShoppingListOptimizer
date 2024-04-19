# ShoppingListOptimizer
docker network create shopping_list_optimizer_network
docker run --network=shopping_list_optimizer_network --name shopping_list_optimizer_db -p 3306:3306 -e MYSQL_ROOT_PASSWORD=password -d mysql:latest
docker compose up --build


dotnet ef migrations add "location0" -p ..\ShoppingListOptimizerAPI.Data
dotnet ef database update

drop database db;
create database db;