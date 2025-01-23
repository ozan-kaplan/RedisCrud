# Redis CRUD Console Application

This project demonstrates a simple **CRUD (Create, Read, Update, Delete)** application using **Redis** with a console-based interface. The application connects to a Redis instance and performs basic key-value operations.

---

## Prerequisites

1. **.NET 8 SDK** installed.
2. **Redis** server running locally or remotely.
   - To start Redis using Docker:
     ```bash
     docker run -d --name redis -p 6379:6379 redis
     ```
3. **NuGet Packages**: Ensure the following package is installed:
   ```bash
   dotnet add package StackExchange.Redis
   ```

---

## Running the Application

### Step 1: Configure Redis Connection

The connection string is set to `localhost:6379` in the application. If your Redis server runs on a different host or port, modify the connection string in the `Program.cs` file:
```csharp
_redis = ConnectionMultiplexer.Connect("<host>:<port>");
```

### Step 2: Run the Application

1. Navigate to the project directory.
2. Run the application:
   ```bash
   dotnet run
   ```
3. Follow the on-screen instructions to perform CRUD operations.

---

## Features

### 1. Create a Record
- Prompts the user to enter a key and a value.
- Stores the key-value pair in Redis.

### 2. Read a Record
- Prompts the user to enter a key.
- Retrieves and displays the value associated with the key.

### 3. Update a Record
- Prompts the user to enter a key and a new value.
- Updates the value for the specified key in Redis.

### 4. Delete a Record
- Prompts the user to enter a key.
- Deletes the specified key-value pair from Redis.

---

## Example Output

### Main Menu:
```
Redis CRUD Example

Choose an operation:
1. Create a new record
2. Read a record
3. Update a record
4. Delete a record
5. Exit
Enter your choice:
```

### Create a Record:
```
Enter key: user:1
Enter value: Ozan Kaplan
Record created successfully!
```

### Read a Record:
```
Enter key: user:1
Value for key 'user:1': Ozan Kaplan
```

### Update a Record:
```
Enter key: user:1
Enter new value: Ozan Kaplan Update
Record updated successfully!
```

### Delete a Record:
```
Enter key: user:1
Record deleted successfully!
```

---

## Project Structure

- **Program.cs**: Main entry point for the application.

---

## Configuration

### Redis Settings
Default Redis connection is configured as:
- Host: `localhost`
- Port: `6379`

To modify these settings, update the connection string in the `Program.cs` file.

---

## License
This project is licensed under the MIT License. Feel free to use, modify, and distribute as needed.

