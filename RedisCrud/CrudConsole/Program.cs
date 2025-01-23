
using StackExchange.Redis;

ConnectionMultiplexer _redis = ConnectionMultiplexer.Connect("localhost:6379");
IDatabase _db = _redis.GetDatabase();

Console.WriteLine("Redis CRUD Example\n");

while (true)
{
    Console.WriteLine("Choose an operation:");
    Console.WriteLine("1. Create a new record");
    Console.WriteLine("2. Read a record");
    Console.WriteLine("3. Update a record");
    Console.WriteLine("4. Delete a record");
    Console.WriteLine("5. Exit");
    Console.Write("Enter your choice: ");

    var choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            await CreateRecordAsync();
            break;
        case "2":
            await ReadRecordAsync();
            break;
        case "3":
            await UpdateRecordAsync();
            break;
        case "4":
            await DeleteRecordAsync();
            break;
        case "5":
            _redis.Close();
            return;
        default:
            Console.WriteLine("Invalid choice. Please try again.\n");
            break;
    }

}


 async Task CreateRecordAsync()
{
    Console.Write("Enter key: ");
    var key = Console.ReadLine();

    Console.Write("Enter value: ");
    var value = Console.ReadLine();

    bool isSet = await _db.StringSetAsync(key, value);

    if (isSet)
    {
        Console.WriteLine("Record created successfully!\n");
    }
    else
    {
        Console.WriteLine("Failed to create the record.\n");
    }
}

 async Task ReadRecordAsync()
{
    Console.Write("Enter key: ");
    var key = Console.ReadLine();

    var value = await _db.StringGetAsync(key);

    if (value.HasValue)
    {
        Console.WriteLine($"Value for key '{key}': {value}\n");
    }
    else
    {
        Console.WriteLine("Key not found.\n");
    }
}

 async Task UpdateRecordAsync()
{
    Console.Write("Enter key: ");
    var key = Console.ReadLine();

    Console.Write("Enter new value: ");
    var value = Console.ReadLine();

    bool isSet = await _db.StringSetAsync(key, value);

    if (isSet)
    {
        Console.WriteLine("Record updated successfully!\n");
    }
    else
    {
        Console.WriteLine("Failed to update the record.\n");
    }
}

 async Task DeleteRecordAsync()
{
    Console.Write("Enter key: ");
    var key = Console.ReadLine();

    bool isDeleted = await _db.KeyDeleteAsync(key);

    if (isDeleted)
    {
        Console.WriteLine("Record deleted successfully!\n");
    }
    else
    {
        Console.WriteLine("Key not found or failed to delete.\n");
    }
}