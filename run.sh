#!/bin/bash
docker-compose down
docker-compose build
docker-compose up -d
docker ps

echo "Frontend: http://localhost:3000"
echo "Backend:  http://localhost:5000"
echo "Postgres: Port 5432 (username: postgres, password: root)"
