#!/bin/bash
COMMIT_SHA=$(git rev-parse HEAD)

docker build -t "jrcasso/4blocks:${COMMIT_SHA:0:10}" .
docker push "jrcasso/4blocks:${COMMIT_SHA:0:10}"
