# MinimalApi-Exemple

A simple and clean example demonstrating how to build a **Minimal API** using **ASP.NET Core**. This project implements a basic **To‑Do API** and is ideal for learning, prototyping, or bootstrapping microservices.

---

## 🚀 Features

- ✅ Minimal API with ASP.NET Core 8
- ✅ Clean and simple architecture
- ✅ Full CRUD operations for To‑Do items
- ✅ Docker support with `.dockerignore` for optimized builds
- ✅ Integrate Swagger for API documentation

---

## 📁 Project Structure

```
MinimalApi-Exemple/
│
├── TodoApi/                ← Main API project
│   ├── Program.cs          ← Entry point with all minimal endpoints
│   └── (Other files)
│
├── TodoApi.sln             ← .NET solution file
├── .gitignore
├── .dockerignore
├── README.md               ← You are here
└── LICENSE.md              ← MIT License
```

---

## 📦 Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- (Optional) [Docker](https://www.docker.com/) for containerization

---

## ▶️ Getting Started

### Run Locally

1. Navigate to the `TodoApi` folder:
   ```bash
   cd TodoApi
   ```

2. Run the application:
   ```bash
   dotnet run
   ```

3. Open your browser or API client and go to:
   ```
   http://localhost:5000/swagger
   ```
   or
   ```
   https://localhost:5001/swagger
   ```

### Run with Docker

1. Build the Docker image:
   ```bash
   docker build -t todoapi .
   ```

2. Run the container:
   ```bash
   docker run -d -p 8080:8080 --name todoapi todoapi
   ```

3. Access the API at:
   ```
   http://localhost:8080/swagger
   ```

---

## 📌 API Endpoints (Example)

- `GET    /todos`         → List all tasks  
- `GET    /todos/{id}`    → Get a task by ID  
- `POST   /todos`         → Create a new task  
- `PUT    /todos/{id}`    → Update an existing task  
- `DELETE /todos/{id}`    → Delete a task  

---

## ✅ Future Improvement

- Add unit tests (e.g., with xUnit)
- Implement authentication (e.g., JWT)
- Set up CI/CD pipelines for deployment
