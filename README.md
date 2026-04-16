# 🚀 AI-102 .NET 8 Azure AI Portfolio

This repository demonstrates a complete hands-on implementation of **Microsoft Azure AI Services** using **.NET 8 Web API** with a clean layered architecture.

The goal of this project is to:

* Build real-world AI-powered APIs
* Use the same codebase for AI Handson Labs

---

# 🧱 Architecture Overview

This solution follows a clean layered architecture:

```
AI102.Api            → Controllers / API Layer
AI102.Application    → Interfaces + DTOs
AI102.Infrastructure → Azure SDK Implementations
AI102.Shared         → Common Responses / Middleware
```

---

# ⚙️ Tech Stack

* .NET 8 Web API
* Azure AI Services
* Azure AI Vision
* Azure AI Language
* Azure AI Document Intelligence
* Swagger (API Testing)
* Clean Architecture Pattern

---

# 📦 Modules Implemented

* ✅ Module 1 - Foundation Setup
* ✅ Module 3 - Azure AI Vision
* ✅ Module 5 - Azure AI Language
* ✅ Module 4 - Azure AI Document Intelligence

---

# 🔹 Module 1 - Foundation

## Features

* Clean architecture setup
* Dependency Injection
* Global exception handling
* Standard API response model
* Health check endpoint

## Endpoint

```http
GET /api/health
```

---

# 🔹 Module 3 - Azure AI Vision (Image Analysis)

## Overview

Azure AI Vision is used to analyze images and extract meaningful insights such as captions, tags, text, and objects.

---

## Features Implemented

* Image Captioning
* Tag Extraction
* OCR (Read Text from Image)
* Object Detection
* Dense Captions

---

## API Endpoints

```http
POST /api/vision/analyze
POST /api/vision/read-text
POST /api/vision/detect-objects
POST /api/vision/dense-captions
```

---

## Sample Request

```http
POST /api/vision/analyze?imageUrl=https://images.unsplash.com/photo-1517841905240-472988babdf9
```

---

## Sample Response

```json
{
  "success": true,
  "message": "Image analyzed successfully",
  "data": {
    "caption": "a dog sitting on grass",
    "tags": ["dog", "grass", "animal"]
  }
}
```

---

## Learning Outcomes

* Image understanding using AI
* OCR implementation
* Object detection concepts
* Working with Azure Vision SDK

---

# 🔹 Module 5 - Azure AI Language Service

## Overview

Azure AI Language is used to analyze and extract insights from text.

---

## Features Implemented

* Sentiment Analysis
* Named Entity Recognition (NER)
* PII Detection
* Key Phrase Extraction

---

## API Endpoints

```http
POST /api/language/sentiment
POST /api/language/entities
POST /api/language/pii
POST /api/language/keyphrases
```

---

## Sample Request

```json
{
  "text": "The product is amazing and the support team was very helpful.",
  "language": "en"
}
```

---

## Sample Response

```json
{
  "success": true,
  "message": "Sentiment analyzed successfully",
  "data": {
    "sentiment": "Positive"
  }
}
```

---

## Learning Outcomes

* Natural Language Processing (NLP)
* Sentiment detection
* Entity recognition
* Sensitive data detection (PII)

---

# 🔹 Module 4 - Azure AI Document Intelligence

## Overview

Azure Document Intelligence extracts structured data from documents like invoices, receipts, and ID cards.

---

## Features Implemented

* Document OCR (Read Text)
* Invoice Data Extraction
* Receipt Data Extraction
* ID Card Analysis

---

## API Endpoints

```http
POST /api/document/read
POST /api/document/invoice
POST /api/document/receipt
POST /api/document/id-card
```

---

## Sample Request

```http
POST /api/document/invoice?fileUrl=https://raw.githubusercontent.com/Azure-Samples/cognitive-services-REST-api-samples/master/curl/form-recognizer/sample-invoice.pdf
```

---

## Sample Response

```json
{
  "success": true,
  "message": "Invoice analyzed successfully",
  "data": {
    "vendorName": "Contoso Ltd.",
    "invoiceId": "12345",
    "totalAmount": 1000.0
  }
}
```

---

## Learning Outcomes

* Structured document processing
* Extracting key-value pairs
* Working with prebuilt AI models
* Real-world enterprise AI use cases

---

# 🔐 Configuration

## Important

Do NOT commit Azure keys in public repositories.

---

## appsettings.json (Safe)

```json
{
  "AzureAI": {
    "Endpoint": "",
    "Key": ""
  }
}
```

---

## appsettings.Development.json (Local Only)

```json
{
  "AzureAI": {
    "Endpoint": "YOUR-ENDPOINT",
    "Key": "YOUR-KEY"
  }
}
```

---

# ▶️ Running the Project

```bash
dotnet restore
dotnet build
dotnet run
```

Open Swagger:

```
https://localhost:<port>/swagger
```

---

# 📈 Future Enhancements

* 🔜 Module 7 - Azure AI Speech
* 🔜 Module 8 - Azure OpenAI
* 🔜 Module 9 - Azure AI Search (RAG)

---

# 🎯 Purpose of This Repository

This project is built to:

* Strengthen Azure AI development skills
* Prepare for AI-102 certification
* Demonstrate real-world API implementations
* Serve as a teaching reference for others

---

# 👨‍💻 Author

Asim Kumar - Azure AI Enthusiast | Tech Lead

---
