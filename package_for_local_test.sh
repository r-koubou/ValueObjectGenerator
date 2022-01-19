#!/bin/sh

# packaging for local test
# NOT for uploading
dotnet build --configuration Release -p:Version=0.0.1 Generator
dotnet pack  --configuration Release --no-build -p:Version=0.0.1 -o ./publish Generator
