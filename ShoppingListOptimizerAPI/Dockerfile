# Use the official image as a parent image.
FROM mcr.microsoft.com/dotnet/aspnet:6.0

# Set the working directory.
WORKDIR /app

COPY ./ShoppingListOptimizer/ShoppingListOptimizerAPI/bin/Release/net6.0/publish/ .
COPY ./ShoppingListOptimizer/ShoppingListOptimizerAPI.Business/bin/Release/net6.0/publish/ .
COPY ./ShoppingListOptimizer/ShoppingListOptimizerAPI.Data/bin/Release/net6.0/publish/ .

# Inform Docker that the container is listening on the specified port at runtime.
EXPOSE 80

# Run the specified command within the container.
ENTRYPOINT ["dotnet", "ShoppingListOptimizerAPI.dll"]
