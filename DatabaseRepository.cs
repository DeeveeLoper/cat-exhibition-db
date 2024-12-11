using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MyCatExhibition;


class DatabaseRepository
{
    public IEnumerable<Owner> GetOwners()
    {
        // Spara i datbasen
        string connectionstring = File.ReadAllText("connectionstring.txt");
        using IDbConnection connection = new SqlConnection(connectionstring);
        
        return connection.Query<Owner>("SELECT owner_id AS OwnerId, name AS Name FROM owner");
    }


    public void InsertOwner(string name)
    {
        // Spara i datbasen
        string connectionstring = File.ReadAllText("connectionstring.txt");
        using IDbConnection connection = new SqlConnection(connectionstring);
        
        string query = $"INSERT INTO owner (name) VALUES ('{name}')";

        connection.Execute(query);
    }


    public void UpdateOwner(int id, string name)
    {
        // Spara i datbasen
        string connectionstring = File.ReadAllText("connectionstring.txt");
        using IDbConnection connection = new SqlConnection(connectionstring);

        string query = $" UPDATE Owner SET name = '{name}' WHERE owner_id = {id}";

        connection.Execute(query);
    }

}
