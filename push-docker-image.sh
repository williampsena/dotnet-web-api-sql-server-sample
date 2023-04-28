#!/bin/bash

build_docker_image() {
    image_name=$1
    image_tag=$2
    docker_file=$3
    registry_repo="willsenabr/$image_name"

    docker build -f $docker_file -t $image_name .

    docker image tag $image_name:latest $registry_repo:latest
    docker image tag $image_name:latest $registry_repo:$image_tag
    docker image push $registry_repo
    docker image push $registry_repo:$image_tag
}

build_docker_image "dotnet-sqlserver" "0.0.1" "Dockerfile"
build_docker_image "dotnet-ef-migrations" "0.0.1" "migration.Dockerfile"


