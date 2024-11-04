# Like Button API Project

## Overview
This project is an API-only implementation of a "Like" button feature using .NET 6. The API allows users to view and increment the number of likes on articles. It is designed to be scalable, handling high traffic and concurrent user interactions efficiently.

## Features
- View the total number of likes for a specific article.
- Increment the like count for an article.
- Optimized for scalability and performance to handle millions of concurrent users.
- Built with best practices for high-availability systems.

## Technology Stack
- **Framework**: .NET 6
- **Database**: SQLite (configurable to use other database engines)
- **Caching**: Redis (recommended for scaling reads)

## Getting Started

### Prerequisites
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQLite](https://www.sqlite.org/download.html) (or any configured database)
- [Docker](https://www.docker.com/) (for containerization)
- [Redis](https://redis.io/download) (optional but recommended)

### Installation Steps
1. **Clone the repository**:
   ```bash
   git clone https://github.com/yourusername/your-repo-name.git
   cd your-repo-name
   ```
2. install dependencies: Ensure you have the .NET 6 SDK installed and restore dependencies:
   ```bash
   dotnet restore
   ```


## API Endpoints
GET /api/like/{articleId}
Description: Retrieves the total number of likes for a specific article.
```bash
GET http://localhost:5000/api/like/d290f1ee-6c54-4b01-90e6-d701748f0851
```



