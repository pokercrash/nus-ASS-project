#!/bin/sh
set -e

# find the first dll in the publish folder and run it
dll=$(ls *.dll | head -n 1)
if [ -z "$dll" ]; then
  echo "No dll found in /app"
  exit 1
fi

exec dotnet "$dll" "$@"
