
## This module demonstrates how to integrate **Azure AI Language Service** into a **.NET 8 Web API** using a clean layered architecture.

### Project Architecture Used
This module follows the same reusable architecture used across the AI-102 portfolio solution:

- **AI102.Api** → Controllers / API endpoints
- **AI102.Application** → Interfaces and DTOs
- **AI102.Infrastructure** → Azure SDK service implementation
- **AI102.Shared** → Common API response models and exception handling

## Module Status

### Module 1 - Foundation 
- [x] Solution setup
- [x] Layered architecture
- [x] Dependency Injection
- [x] Configuration binding
- [x] Swagger integration
- [x] Exception middleware
- [x] Health API tested

### Module 3 - Computer Vision
- [x] Vision service interface
- [x] Vision service implementation
- [x] Vision controller
- [x] Image analysis endpoint
- [ ] Azure AI Vision live integration
- [ ] Live endpoint validation

## Module 5 - Azure AI Language Service
- [x] Sentiment Analysis
- [x] Named Entity Recognition (NER)
- [x] Personally Identifiable Information (PII) Detection
- [x] Key Phrase Extraction