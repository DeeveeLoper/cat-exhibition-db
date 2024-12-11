using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MyCatExhibition;

class DatabaseRepository
{

    //---------------- Ägare ----------------------------

    public IEnumerable<Owner> GetOwners()
    {
        string connectionstring = File.ReadAllText("connectionstring.txt");
        using IDbConnection connection = new SqlConnection(connectionstring);
        return connection.Query<Owner>("SELECT owner_id AS OwnerId, name AS Name FROM owner");
    }

    public void InsertOwner(string name)
    {
        string connectionstring = File.ReadAllText("connectionstring.txt");
        using IDbConnection connection = new SqlConnection(connectionstring);
        string query = $"INSERT INTO owner (name) VALUES ('{name}')";
        connection.Execute(query);
    }

    public void UpdateOwner(int id, string name)
    {
        string connectionstring = File.ReadAllText("connectionstring.txt");
        using IDbConnection connection = new SqlConnection(connectionstring);
        string query = $" UPDATE Owner SET name = '{name}' WHERE owner_id = {id}";
        connection.Execute(query);
    }

    public void DeleteOwner(int id)
    {
        string connectionstring = File.ReadAllText("connectionstring.txt");
        using IDbConnection connection = new SqlConnection(connectionstring);
        string query = $" DELETE FROM Owner WHERE owner_id = {id}";
        connection.Execute(query);
    }


    //---------------- Utställning ----------------------------

    public IEnumerable<Exhibition> GetExhibitions()
    {
        string connectionstring = File.ReadAllText("connectionstring.txt");
        using IDbConnection connection = new SqlConnection(connectionstring);
        return connection.Query<Exhibition>("SELECT exhibition_id AS ExhibitionId, name AS Name, exhibition_date AS ExhibitionDate FROM exhibition");
    }

    public void InsertExhibition(string name, DateTime exhibtionDate)
    {
        string connectionstring = File.ReadAllText("connectionstring.txt");
        using IDbConnection connection = new SqlConnection(connectionstring);
        string query = $"INSERT INTO exhibition (name, exhibition_date) VALUES ('{name}', '{exhibtionDate}')";
        connection.Execute(query);
    }

    public void UpdateExhibition(int id, string name, DateTime exhibitionDate)
    {
        string connectionstring = File.ReadAllText("connectionstring.txt");
        using IDbConnection connection = new SqlConnection(connectionstring);
        string query = $" UPDATE Exhibition SET name = '{name}', exhibition_date = '{exhibitionDate}' WHERE exhibition_id = {id}";
        connection.Execute(query);
    }

    public void DeleteExhibition(int id)
    {
        string connectionstring = File.ReadAllText("connectionstring.txt");
        using IDbConnection connection = new SqlConnection(connectionstring);

        string queryTable = $" DELETE FROM cat_to_exhibition WHERE exhibition_id = {id}";
        connection.Execute(queryTable);

        string queryExhibition = $" DELETE FROM exhibition WHERE exhibition_id = {id}";
        connection.Execute(queryExhibition);
    }


    //---------------- Katt ----------------------------

    public IEnumerable<Cat> GetCats()
    {
        string connectionstring = File.ReadAllText("connectionstring.txt");
        using IDbConnection connection = new SqlConnection(connectionstring);
        return connection.Query<Cat>("SELECT cat_id AS CatId, name AS Name, age AS Age FROM cat");
    }

    public void InsertCat(string name, int age)
    {
        string connectionstring = File.ReadAllText("connectionstring.txt");
        using IDbConnection connection = new SqlConnection(connectionstring);
        string query = $"INSERT INTO cat (name, age) VALUES ('{name}', '{age}')";
        connection.Execute(query);
    }

    public void UpdateCat(int id, string name, int age)
    {
        string connectionstring = File.ReadAllText("connectionstring.txt");
        using IDbConnection connection = new SqlConnection(connectionstring);
        string query = $" UPDATE cat SET name = '{name}', age = '{age}' WHERE cat_id = {id}";
        connection.Execute(query);
    }

    public void DeleteCat(int id)
    {
        string connectionstring = File.ReadAllText("connectionstring.txt");
        using IDbConnection connection = new SqlConnection(connectionstring);

        string queryTable = $" DELETE FROM cat_to_exhibition WHERE cat_id = {id}";
        connection.Execute(queryTable);

        string queryExhibition = $" DELETE FROM cat WHERE cat_id = {id}";
        connection.Execute(queryExhibition);
    }
}
