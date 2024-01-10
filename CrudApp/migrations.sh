#!/bin/bash

bash /wait-for-it/wait-for-it.sh db:5432

cd /app/source
dotnet restore
dotnet ef database update
rm -rf /app/source 
cd /app/
dotnet CrudApp.dll

