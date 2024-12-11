using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MyCatExhibition;


class DatabaseRepository
{
    //---------------- Owner ----------------------------

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

    public void DeleteOwner(int id)
    {
        // Spara i datbasen
        string connectionstring = File.ReadAllText("connectionstring.txt");
        using IDbConnection connection = new SqlConnection(connectionstring);

        string query = $" DELETE FROM Owner WHERE owner_id = {id}";

        connection.Execute(query);
    }


    //---------------- Exhibition ----------------------------

    public IEnumerable<Exhibition> GetExhibitions()
    {
        // Spara i datbasen
        string connectionstring = File.ReadAllText("connectionstring.txt");
        using IDbConnection connection = new SqlConnection(connectionstring);

        return connection.Query<Exhibition>("SELECT exhibition_id AS ExhibitionId, name AS Name, exhibition_date AS ExhibitionDate FROM exhibition");
    }


    public void InsertExhibition(string name, DateTime exhibtionDate)
    {
        // Spara i datbasen
        string connectionstring = File.ReadAllText("connectionstring.txt");
        using IDbConnection connection = new SqlConnection(connectionstring);

        string query = $"INSERT INTO exhibition (name, exhibition_date) VALUES ('{name}', '{exhibtionDate}')";

        connection.Execute(query);
    }


    public void UpdateExhibition(int id, string name, DateTime exhibitionDate)
    {
        // Spara i datbasen
        string connectionstring = File.ReadAllText("connectionstring.txt");
        using IDbConnection connection = new SqlConnection(connectionstring);

        string query = $" UPDATE Exhibition SET name = '{name}', exhibition_date = '{exhibitionDate}' WHERE exhibition_id = {id}";

        connection.Execute(query);
    }

    public void DeleteExhibition(int id)
    {
        // Spara i datbasen
        string connectionstring = File.ReadAllText("connectionstring.txt");
        using IDbConnection connection = new SqlConnection(connectionstring);

        string queryTable = $" DELETE FROM cat_to_exhibition WHERE exhibition_id = {id}";
        connection.Execute(queryTable);

        string queryExhibition = $" DELETE FROM exhibition WHERE exhibition_id = {id}";
        connection.Execute(queryExhibition);
    }


    //---------------- Cat ----------------------------

}
