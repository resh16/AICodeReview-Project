# 🤖 AI Code Reviewer


# 📌 Project Objective
Build an AI-powered platform that reviews submitted source code files (.cs files) and provides feedback on code quality, structure, and best practices using an existing AI model. The project is built using microservices to practice Docker and Kubernetes-based deployment and ensure scalability and modularity.

# 🚀 Future Scope
Support multiple languages (.py, .js, etc.)

Integrate real-time collaboration tools

Dashboard for code insights and review history

Role-based access and team collaboration

Connect to GitHub repositories for auto review

# 💡 Value Proposition
This tool helps developers:

Get instant feedback on their code

Learn and improve coding practices

Save time during code reviews

Maintain quality and consistency in large projects

# 🧰 Tech Stack

**Frontend** -	Angular (planned)

**Backend**	- ASP.NET Core 8 Web API

**Microservices** - Clean architecture, REST

**Message Broker** - RabbitMQ (planned)

**Auth** -	ASP.NET Identity + JWT

**API Gateway** -	Ocelot (planned)

**Communication** -	REST (gRPC later)

**AI Integration** -	Ollama  (local LLM - replaces OpenAI for free usage)

**Version Control** -	Git + GitHub

**Deployment** -	Docker (Kubernetes planned)

**DB** -	SQL Server

# Project Structure

AI.CodeReviewer.sln

├── AuthService (Microsoft Identity tables +JWT )

├── CodeSubmissionService (Handles Uploads, Basic feedback, e.g., what the code does, First-level validation/feedback )

├── AIAnalysisService (Advanced insights: logic issues, suggestions, refactoring)

├── ReportService (PDF/HTML report)

├── APIGateway


# 🔐 AuthService.API – Authentication & Authorization Service
This microservice handles user authentication, authorization, and identity management using JWT tokens and ASP.NET Identity.

# ✅ Features Implemented:

- User Registration

- New users can register with email and password.

- Password is securely hashed using ASP.NET Identity.

- User Login

- Users can log in using valid credentials.

- On successful login, a JWT token is generated and returned.

- JWT Token Generation & Validation

- Secure tokens generated with claims like UserId, Email, and roles.

- Token expiry and signing handled via appsettings.json config.

- Role-Based Authorization (not implemented now)

- Supports user roles (e.g., Admin, User).

- Role claims added to JWT.

- Token-based API Protection

- Endpoints protected using [Authorize] attribute.

- Authenticated users only can access protected routes.

- Identity Integration

- Uses IdentityUser and built-in UserManager, SignInManager.

- EF Core used to manage identity tables in the DB.

- Validation & Error Handling

- Custom error messages for invalid login or registration.

- Model validation included for user inputs.

# 🛠️ Tech Stack:
- ASP.NET Core Web API

- Entity Framework Core

- ASP.NET Core Identity

- JWT Bearer Authentication

- SQL Server (for Identity DB)

 # 🧠 CodeSubmissionService.API – Code Submission & AI Feedback Service
This microservice allows users to submit code and receive automated analysis and feedback using the Code Llama AI model via Ollama.

## 🧠 CodeLlama
### What:
→ It's a large language model (LLM) trained specially for coding and code generation.

→ Think of it like ChatGPT but much better at understanding and writing code.

### Why:
→ Used to analyze code, suggest improvements, fix errors, generate code snippets, etc.

## 🛠️ Ollama
### What:
→ It's a tool and server that makes it super easy to run LLMs locally on your machine (like CodeLlama).

→ Instead of complicated setups, Ollama handles downloading, running, and serving models via simple APIs.

### Why:
→ You can use models like CodeLlama locally through API requests (like from Postman, your app, etc.)

→ No need for OpenAI API or paid services.

## 🔥 In short:
- CodeLlama = Smart model for code understanding and generation.

- Ollama = App that hosts CodeLlama (and other models) on your local machine easily.

# ✅ Features Implemented:

## Code Submission Endpoint

- Accepts a code snippet (string code) and optionally the language (default: csharp).

- Expects code input via API POST request.

## AI-Based Code Analysis (Code Llama + Ollama)

- Integrated with Ollama (via local Docker or app) running the codellama model.

- Code is sent as a prompt to the local AI model, and a response with feedback is returned.

- The service handles prompt formatting and parsing AI responses.

## Response Model

- Returns feedback in the form of:

{
  "feedback": "Descriptive suggestion or correction",
  "isSuccess": true
}

## Dockerized Ollama Integration

### CMD Commands:
- Install docker and pull the Ollama dockerImage : docker pull ollama/ollama
  
- Run the Ollama container in background : docker run -d --name ollama -p 11434:11434 ollama/ollama
  
- Start the container: docker start ollama

- Check running containers: docker ps

- Pull the model: docker exec -it ollama ollama pull codellama (if not already done)

- Run the model: docker exec -it ollama ollama run codellama

- Verify with curl: curl http://localhost:11434/api/generate

- Stop the container: docker stop ollama when you're done
- 
- Exposed at http://localhost:11434.

## Internal Service Layer

- Code submission is processed via CodeAnalysisService, which encapsulates the logic for sending the prompt to the AI model and formatting the response.

# 🛠️ Tech Stack:
- ASP.NET Core Web API

- Ollama (AI runtime)

- Code Llama (AI model)

- Docker (for running Ollama container)


# AIAnalysisService.API

## 📌 Overview

The `AIAnalysisService.API` is a microservice within the AI Code Reviewer ecosystem. It is responsible for analyzing the **improvements made to code submissions** and providing **intelligent feedback** using a locally hosted LLM model (CodeLlama via Ollama). This service works after a user refines their code based on suggestions and chooses to validate those improvements.

---

## 🎯 Purpose

- Validate if the improved code version is better than the original.
- Offer meaningful AI-driven feedback highlighting improvements or areas for enhancement.
- Optionally track analysis history (e.g., using MongoDB in future phases).

---

## 🏗️ Implementation Highlights

- **Receives**: Original code and improved version from CodeSubmissionService.
- **Processes**: Generates a dynamic prompt using a `.txt` template.
- **Sends**: POST request to local Ollama server (running CodeLlama model).
- **Parses**: AI response to determine if the improvement is valid and meaningful.
- **Returns**: Feedback and status (`isImproved`) to the caller.

---

## ⚙️ Tech Stack

| Tech               | Purpose                                   |
|--------------------|-------------------------------------------|
| ASP.NETCore Web API| Core service framework                    |
| Ollama + CodeLlama | Local AI model for code understanding     |
| HttpClient         | Inter-service & AI model communication    |
| .NET 8             | Target framework                          |
| Swagger/OpenAPI    | API documentation and testing             |
| File I/O (Prompt)  | Template-based dynamic prompt generation  |

---

## 🧩 Key Components

- `CodeAnalysisRequest.cs` – DTO for input containing original and improved code.
- `CodeAnalysisResponse.cs` – DTO representing analysis feedback and result.
- `AIAnalysisService - AnalyzeCodeImprovement()` – Core method calling Ollama and parsing response.
- `Prompt/CodeImprovementPrompt.txt` – Template file for creating the LLM prompt.
- `AIAnalysisController.cs` – Endpoint to trigger the analysis.

---

## 🚀 Future Enhancements

- Add **MongoDB** to persist code analysis history.
- Enable **user identification** to associate feedback records.
- Visualize analysis history in the UI.
- Integrate advanced diffing or line-by-line comparison.

---

## 📬 API Endpoint

- `POST /api/Analysis`
  - **Input**: `originalCode`, `improvedCode`, `language`
  - **Output**: orginalCode, improvedCode, timestamp, feedback,IsImproved

---

> 💡 This service is designed to be modular and replaceable with more advanced AI models or engines as needed in future versions.

