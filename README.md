# 🚀 AI-102 .NET 8 Azure AI Portfolio

This repository demonstrates a complete hands-on implementation of **Microsoft Azure AI Services** using **.NET 8 Web API** with a clean layered architecture.

The goal of this project is to:

* Build real-world AI-powered APIs
* Practice Azure AI-102 concepts through code
* Use the same codebase for Practice and learning

---

# 🧱 Architecture Overview

```text id="arch01"
AI102.Api            → Controllers / API Layer  
AI102.Application    → Interfaces + DTOs  
AI102.Infrastructure → Azure SDK Implementations  
AI102.Shared         → Common Responses / Middleware  
```

---

# ⚙️ Tech Stack

* .NET 8 Web API
* Azure AI Vision
* Azure AI Language
* Azure AI Document Intelligence
* Azure AI Speech
* Azure OpenAI (LLM)
* Swagger (API Testing)
* Clean Architecture Pattern

---

# 📦 Modules Implemented

* ✅ Module 1 - Foundation Setup
* ✅ Module 3 - Azure AI Vision
* ✅ Module 5 - Azure AI Language
* ✅ Module 4 - Azure AI Document Intelligence
* ✅ Module 7 - Azure AI Speech
* ✅ Module 8 - Azure OpenAI

---

# 🔹 Module 1 - Foundation

## Features

* Clean architecture setup
* Dependency Injection
* Global exception handling
* Standard API response model
* Health check endpoint

## Endpoint

```http id="ep01"
GET /api/health
```

---

# 🔹 Module 3 - Azure AI Vision

## Overview

Analyze images and extract insights such as captions, tags, text, and objects.

## Features

* Image Captioning
* Tag Extraction
* OCR (Read Text)
* Object Detection
* Dense Captions

## Endpoints

```http id="ep02"
POST /api/vision/analyze  
POST /api/vision/read-text  
POST /api/vision/detect-objects  
POST /api/vision/dense-captions  
```

## Sample Response

```json id="res01"
{
  "caption": "a dog sitting on grass",
  "tags": ["dog", "grass"]
}
```

---

# 🔹 Module 5 - Azure AI Language

## Overview

Analyze and extract intelligence from text.

## Features

* Sentiment Analysis
* Named Entity Recognition
* PII Detection
* Key Phrase Extraction

## Endpoints

```http id="ep03"
POST /api/language/sentiment  
POST /api/language/entities  
POST /api/language/pii  
POST /api/language/keyphrases  
```

---

# 🔹 Module 4 - Document Intelligence

## Overview

Extract structured data from documents.

## Features

* OCR (Read)
* Invoice Analysis
* Receipt Analysis
* ID Card Extraction

## Endpoints

```http id="ep04"
POST /api/document/read  
POST /api/document/invoice  
POST /api/document/receipt  
POST /api/document/id-card  
```

---

# 🔹 Module 7 - Azure AI Speech

## Overview

Convert speech ↔ text using AI.

## Features

* Speech to Text
* Text to Speech

## Endpoints

```http id="ep05"
POST /api/speech/speech-to-text  
POST /api/speech/text-to-speech  
```

---

# 🔹 Module 8 - Azure OpenAI (GenAI)

## Overview

Leverage Large Language Models (LLMs) for intelligent text generation and transformation.

## Features

* Chat Completion
* Text Summarization
* Key Information Extraction
* Text Rewriting

---

## Endpoints

```http id="ep06"
POST /api/openai/chat  
POST /api/openai/summarize  
POST /api/openai/extract  
POST /api/openai/rewrite  
```

---

## Sample Request

```json id="req02"
{
  "prompt": "Explain Azure AI in simple terms"
}
```

---

## Sample Response

```json id="res02"
{
  "response": "Azure AI is a collection of cloud-based services..."
}
```

---

## Learning Outcomes

* Prompt engineering basics
* LLM integration in .NET
* Real-world GenAI use cases
* API-based AI architecture

---

# 🔐 Configuration

⚠️ Do NOT commit Azure keys.

## appsettings.json

```json id="cfg01"
{
  "AzureAI": {
    "Endpoint": "",
    "Key": "",
    "OpenAIEndpoint": "",
    "OpenAIKey": "",
    "DeploymentName": "gpt-4o-mini"
  }
}
```

---

## appsettings.Development.json

```json id="cfg02"
{
  "AzureAI": {
    "Endpoint": "YOUR-ENDPOINT",
    "Key": "YOUR-KEY",
    "OpenAIEndpoint": "YOUR-OPENAI-ENDPOINT",
    "OpenAIKey": "YOUR-OPENAI-KEY",
    "DeploymentName": "gpt-4o-mini"
  }
}
```

---

# ▶️ Run the Project

```bash id="run01"
dotnet restore  
dotnet build  
dotnet run  
```

Swagger:

```text id="run02"
https://localhost:<port>/swagger
```

---

# 📈 Future Enhancements

* 🔜 Module 9 — RAG (Azure AI Search + OpenAI)

---

# 🎯 Purpose

* Azure AI-102 preparation
* Real-world backend AI development
* Practice & learning

---

# 👨‍💻 Author

Asim Kumar - Azure AI Enthusiast | Tech Lead

---
