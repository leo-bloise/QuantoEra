#!/bin/bash

# Build the Docker image
echo "Building Docker image..."
docker build -t quantoera-web .

# Check if the build was successful
if [ $? -eq 0 ]; then
    echo "Docker image built successfully."
    echo "Running Docker container..."
    # Run the Docker container, mapping port 5289
    docker run -d -p 8080:8080 --name quantoera-app quantoera-web
    
    if [ $? -eq 0 ]; then
        echo "Docker container 'quantoera-app' started successfully on port 8080."
        echo "You can access the application at http://localhost:8080"
    else
        echo "Failed to start Docker container."
    fi
else
    echo "Docker image build failed."
fi
