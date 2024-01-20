#!/bin/bash

bash /wait-for-it/wait-for-it.sh db:5432

dotnet restore
dotnet ef database update