# Memorization Techniques API Specification

This specification follows the **OpenAPI 3.0** standard for a RESTful architecture, designed for easy integration with Swagger/OpenAPI tools.

---

## 1. API Overview

* **Version:** `v1`
* **Payload Format:** `application/json`
* **Authentication:** None (JWT será implementado em fase futura)

---

## 2. Entity-Relationship Model (Conceptual)

* **`Content`** (1) $\rightarrow$ ($\infty$) **`MemorizationTechnique`**
  * A single content item to be memorized can have multiple associated memorization techniques (e.g., Acronym, Mind Palace, Visual Association, Spaced Repetition).

---

## 3. Endpoints

### 3.1. Create Content to Memorize

Creates a new topic, text, fact, or subject that the user needs to learn and retain.

* **HTTP Method:** `POST`
* **Path:** `/api/v1/contents`

#### Request Header
```http
Content-Type: application/json
```

#### Request Body
```json
{
  "title": "Essential Amino Acids List",
  "category": "Biology",
  "originalText": "Histidine, Isoleucine, Leucine, Lysine, Methionine, Phenylalanine, Threonine, Tryptophan, Valine",
  "notes": "Mnemonic required for biochemistry exam"
}
```

#### Response: `201 Created`
```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66aa35",
  "title": "Essential Amino Acids List",
  "category": "Biology",
  "originalText": "Histidine, Isoleucine, Leucine, Lysine, Methionine, Phenylalanine, Threonine, Tryptophan, Valine",
  "notes": "Mnemonic required for biochemistry exam",
  "createdAt": "2026-10-19T09:25:00Z"
}
```

---

### 3.2. List Contents

Retrieves a paginated list of registered contents.

* **HTTP Method:** `GET`
* **Path:** `/api/v1/contents?page=1&pageSize=10`

#### Response: `200 OK`
```json
{
  "items": [
    {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66aa35",
      "title": "Essential Amino Acids List",
      "category": "Biology",
      "totalTechniques": 2,
      "createdAt": "2026-10-19T09:25:00Z"
    }
  ],
  "page": 1,
  "pageSize": 10,
  "totalRecords": 1
}
```

---

### 3.3. Create / Save Memorization Technique

Associates a new memorization technique with an existing content entry.

* **HTTP Method:** `POST`
* **Path:** `/api/v1/contents/{contentId}/techniques`

#### Path Parameters
* `contentId` *(string/UUID, required)*: Unique identifier of the associated content.

#### Request Body
```json
{
  "techniqueType": "ACRONYM",
  "title": "PVT TIM HALL Mnemonic",
  "description": "Mnemonic phrase created to remember the first letter of each essential amino acid.",
  "generatedContent": "Think of the phrase: 'Private Tim Hall'",
  "generationOrigin": "IA_ASSISTED",
  "isFavorite": false
}
```

> `isFavorite` *(boolean, optional)*: Marks the technique as a favorite. Defaults to `false` if not provided.

#### Allowed Values for `techniqueType`
`ACRONYM` | `MIND_PALACE` | `ASSOCIATIVE_STORY` | `SPACED_REPETITION` | `MIND_MAP` | `OTHER`

#### Allowed Values for `generationOrigin`
`MANUAL` | `IA_ASSISTED`

#### Response: `201 Created`
```json
{
  "id": "e7b8c8d2-1234-4567-89ab-cdef01234567",
  "contentId": "3fa85f64-5717-4562-b3fc-2c963f66aa35",
  "techniqueType": "ACRONYM",
  "title": "PVT TIM HALL Mnemonic",
  "description": "Mnemonic phrase created to remember the first letter of each essential amino acid.",
  "generatedContent": "Think of the phrase: 'Private Tim Hall'",
  "generationOrigin": "IA_ASSISTED",
  "isFavorite": true,
  "createdAt": "2026-10-19T09:25:00Z"
}
```

---

### 3.4. Update Memorization Technique

Modifies details of an existing technique (e.g., generated content, description, title, favorite status).

* **HTTP Method:** `PUT`
* **Path:** `/api/v1/techniques/{id}`

#### Path Parameters
* `id` *(string/UUID, required)*: Unique identifier of the technique to update.

#### Request Body
```json
{
  "title": "PVT TIM HALL Mnemonic (Updated)",
  "description": "Adjusted mnemonic for improved visual clarity.",
  "generatedContent": "Think of the phrase: 'Private Tim Hall' (Pvt Tim Hall)",
  "isFavorite": true
}
```

#### Response: `200 OK`
```json
{
  "id": "e7b8c8d2-1234-4567-89ab-cdef01234567",
  "contentId": "3fa85f64-5717-4562-b3fc-2c963f66aa35",
  "techniqueType": "ACRONYM",
  "title": "PVT TIM HALL Mnemonic (Updated)",
  "description": "Adjusted mnemonic for improved visual clarity.",
  "generatedContent": "Think of the phrase: 'Private Tim Hall' (Pvt Tim Hall)",
  "generationOrigin": "IA_ASSISTED",
  "isFavorite": true,
  "updatedAt": "2026-10-19T09:30:00Z"
}
```

---

### 3.5. List Techniques for Content

Retrieves all generated and saved techniques for a specific content item.

* **HTTP Method:** `GET`
* **Path:** `/api/v1/contents/{contentId}/techniques`

#### Response: `200 OK`
```json
[
  {
    "id": "e7b8c8d2-1234-4567-89ab-cdef01234567",
    "techniqueType": "ACRONYM",
    "title": "PVT TIM HALL Mnemonic",
    "generatedContent": "Think of the phrase: 'Private Tim Hall'",
    "generationOrigin": "IA_ASSISTED",
    "isFavorite": true,
    "createdAt": "2026-10-19T09:25:00Z"
  }
]
```

---

### 3.6. Delete Memorization Technique

Deletes a specific memorization technique.

* **HTTP Method:** `DELETE`
* **Path:** `/api/v1/techniques/{id}`

#### Response: `204 No Content`

---

## 4. Standardized Error Handling (RFC 7807 - Problem Details)

All error responses adhere to the RFC 7807 problem details specification:

#### Example: `400 Bad Request` (Validation Error)
```json
{
  "type": "https://api.example.com/errors/bad-request",
  "title": "Validation Error",
  "status": 400,
  "detail": "One or more fields contain invalid values.",
  "instance": "/api/v1/contents/3fa85f64-5717-4562-b3fc-2c963f66aa35/techniques",
  "errors": [
    {
      "field": "techniqueType",
      "message": "The techniqueType field is required and must be a valid enum value."
    }
  ]
}
```

#### Example: `404 Not Found`
```json
{
  "type": "https://api.example.com/errors/not-found",
  "title": "Resource Not Found",
  "status": 404,
  "detail": "The content with the specified ID was not found.",
  "instance": "/api/v1/contents/3fa85f64-5717-4562-b3fc-2c963f66aa35/techniques"
}
```

---

## 5. Database Schema / DDL (SQL Server / PostgreSQL)

Relational database schema reference:

```sql
CREATE TABLE Contents (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Title VARCHAR(200) NOT NULL,
    Category VARCHAR(100) NULL,
    OriginalText VARCHAR(MAX) NOT NULL,
    Notes VARCHAR(500) NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE()
);

CREATE TABLE MemorizationTechniques (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    ContentId UNIQUEIDENTIFIER NOT NULL,
    TechniqueType VARCHAR(50) NOT NULL,
    Title VARCHAR(200) NOT NULL,
    Description VARCHAR(MAX) NULL,
    GeneratedContent VARCHAR(MAX) NOT NULL,
    GenerationOrigin VARCHAR(30) NOT NULL, -- 'MANUAL' or 'IA_ASSISTED'
    IsFavorite BIT NOT NULL DEFAULT 0,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME2 NULL,
    CONSTRAINT FK_Techniques_Content FOREIGN KEY (ContentId) REFERENCES Contents(Id) ON DELETE CASCADE
);
```