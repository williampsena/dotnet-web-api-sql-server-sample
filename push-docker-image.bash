#!/bin/bash
IMAGE_NAME="dotnet-sqlserver"
IMAGE_TAG="0.0.1"
REGISTRY_REPO="willsenabr/$IMAGE_NAME"

docker build -t $IMAGE_NAME .

docker image tag $IMAGE_NAME:latest $REGISTRY_REPO:latest
docker image tag $IMAGE_NAME:latest $REGISTRY_REPO:$IMAGE_TAG
docker image push willsenabr/$IMAGE_NAME
docker image push willsenabr/$IMAGE_NAME:$IMAGE_TAG