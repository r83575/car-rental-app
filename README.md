# Car Rental App

Frontend: React  
Backend: .NET  

## Prerequisites
- Node.js (for client)
- .NET SDK (for server)
- SQL Server (for database)

## Setup

### Client
```bash
cd client
npm install
npm run dev
```

### Server
```bash
cd server/project
dotnet run
```

### Database
1. Open SQL Server Management Studio (SSMS) or your preferred SQL tool.
2. Connect to your local SQL Server instance.
3. Open and run the script `DB/script.sql` to create the database "Car" and insert initial data.
   - This will create the database with all necessary tables and sample data.

## Usage
1. Run the database setup (if not done).
2. Start the server: `cd server/project && dotnet run`
3. Start the client: `cd client && npm run dev`
4. Access the app in your browser at http://localhost:5173.