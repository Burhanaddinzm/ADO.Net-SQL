using Microsoft.Data.SqlClient;

string connectionString = "Server=SUN01;Database=Shop;Trusted_Connection=true;TrustServerCertificate=True;";

SqlConnection sqlConnection = new SqlConnection(connectionString);

void Create()
{
    Console.WriteLine("Insert Name:");
    string Name = Console.ReadLine();
    sqlConnection.Open();
    SqlCommand sqlCommand = new SqlCommand($"INSERT INTO Category VALUES('{Name}')", sqlConnection);
    int result = sqlCommand.ExecuteNonQuery();
    sqlConnection.Close();

    if (result == 0)
        Console.WriteLine("Error occured while executing SQL querry!");
    else
        Console.WriteLine($"{result} rows effected");
}

void Delete()
{
    Console.WriteLine("Insert Name:");
    string Name = Console.ReadLine();
    sqlConnection.Open();
    SqlCommand sqlCommand = new SqlCommand($"DELETE FROM Category WHERE Name=('{Name}')", sqlConnection);
    int result = sqlCommand.ExecuteNonQuery();
    sqlConnection.Close();

    if (result == 0)
        Console.WriteLine("Error occured while executing SQL querry!");
    else
        Console.WriteLine($"{result} rows effected");
}

void Update()
{
    Console.WriteLine("Insert Name:");
    string Name = Console.ReadLine();

    Console.WriteLine("Insert Updated Name:");
    string UpdatedName = Console.ReadLine();

    sqlConnection.Open();
    SqlCommand sqlCommand = new SqlCommand($"UPDATE Category SET Name='{UpdatedName}' WHERE Name='{Name}'", sqlConnection);
    int result = sqlCommand.ExecuteNonQuery();
    sqlConnection.Close();

    if (result == 0)
        Console.WriteLine("Error occured while executing SQL querry!");
    else
        Console.WriteLine($"{result} rows effected");
}

void GetAll()
{
    sqlConnection.Open();
    SqlCommand command = new SqlCommand("SELECT * FROM Category", sqlConnection);
    SqlDataReader reader = command.ExecuteReader();

    while (reader.Read())
        Console.WriteLine($"Id:{reader["Id"]} Name:{reader["Name"]}");

    sqlConnection.Close();
}

void Get()
{
    Console.WriteLine("Input Name:");
    string Name = Console.ReadLine();

    sqlConnection.Open();
    SqlCommand command = new SqlCommand("SELECT * FROM Category", sqlConnection);
    SqlDataReader reader = command.ExecuteReader();

    while (reader.Read())
    {
        if (Name == reader["Name"])
            Console.WriteLine($"Id:{reader["Id"]} Name:{reader["Name"]}");
    }
    sqlConnection.Close();
}

void App()
{
    ShowMenu();
    int request = int.Parse(Console.ReadLine());

    while (request != 0)
    {
        switch (request)
        {
            case 1:
                Create();
                break;
            case 2:
                Delete();
                break;
            case 3:
                Update();
                break;
            case 4:
                GetAll();
                break;
            case 5:
                Get();
                break;

            default:
                break;
        }
        ShowMenu();
        request = int.Parse(Console.ReadLine());
    }


}

void ShowMenu()
{
    Console.WriteLine("1. Create");
    Console.WriteLine("2. Delete");
    Console.WriteLine("3. Update");
    Console.WriteLine("4. GetAll");
    Console.WriteLine("5. Get");
    Console.WriteLine("0. Close");
}

App();