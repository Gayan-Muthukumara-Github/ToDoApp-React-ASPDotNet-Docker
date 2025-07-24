# TODO App - Full Stack (React + ASP.NET Core + PostgreSQL + Docker)

This is a simple full-stack TODO application built with:

- **Backend:** ASP.NET Core Web API
- **Frontend:** React.js
- **Database:** PostgreSQL
- **Deployment:** Docker & Docker Compose

---

## Project Structure

```

ToDoApp/
│
├── todo-backend/         # ASP.NET Core Web API
├── todo-frontend/        # React Frontend
├── docker-compose.yml    # Docker orchestration
└── run.sh                # Shell script to build and run everything

````

---

## Prerequisites

- [Docker Desktop](https://www.docker.com/products/docker-desktop/) installed and running
- [Git](https://git-scm.com/) installed
- (Optional) [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) if running backend locally without Docker
- (Optional) [Node.js & npm](https://nodejs.org/) if running frontend locally without Docker

---

## Build & Run with Docker

1. Clone the repo:
   ```bash
   git clone https://github.com/Gayan-Muthukumara-Github/ToDoApp-React-ASPDotNet-Docker.git
   cd ToDoApp-React-ASPDotNet-Docker
   ````

2. Run the full app using Docker:

   ```bash
   ./run.sh  # Linux/Mac
   ```

   or

   ```powershell
   bash run.sh  # Windows with Git Bash or WSL
   ```

3. Access the app:

   * Frontend: [http://localhost:3000](http://localhost:3000)
   * Backend API: [http://localhost:5000/api](http://localhost:5000/api)
   * PostgreSQL: Port 5432 (username: `postgres`, password: `root`)

---

## Run Without Docker (Optional)

### Backend (ASP.NET Core)

```bash
cd todo-backend
dotnet restore
dotnet run
```

API will run at: `http://localhost:5000`

### Frontend (React)

```bash
cd todo-frontend
npm install
npm start
```

Frontend will run at: `http://localhost:3000`

---

## Environment Variables (optional `.env` support)

You can configure environment variables (e.g., connection strings) inside:

* `todo-backend/appsettings.json`
* `todo-frontend/.env`

---

## Author

**Gayan Muthukumara**
GitHub: [@Gayan-Muthukumara-Github](https://github.com/Gayan-Muthukumara-Github)

---

