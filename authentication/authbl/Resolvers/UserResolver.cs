using System.Data;
using Cims.WorkflowLib.DbConnections;
using WokflowLib.Authentication.Models;
using WokflowLib.Authentication.Models.NetworkParameters;

namespace DeliveryService.Authentication.AuthWebApi.AuthBL;

public class UserResolver
{
    private PgDbConnection PgDbConnection { get; }
    private string ConnectionString { get; }

    public UserResolver()
    {
        ConnectionString = "Server=127.0.0.1;Port=5432;Userid=postgres;Password=postgres;Database=postgres";
        PgDbConnection = new PgDbConnection(ConnectionString);
    }

    /// <summary>
    /// Execute SQL query to get if a user with specified credentials exists in the DB
    /// </summary>
    public void CheckUserExistance(UserCredentials request, UserExistance response)
    {
        try
        {
            // Redirect the request 
            string sql = @$"-- 
select 1 as credentials_type, count(*) as qty from users where login = {request.Login}
union 
select 2 as credentials_type, count(*) as qty from users where email = {request.Email}
union
select 2 as credentials_type, count(*) as qty from users where phone_number = {request.PhoneNumber}
;";
            // Execute SQL statement 
            // 
            response.LoginExists = true;
            response.EmailExists = true;
            response.PhoneNumberExists = true;
        }
        catch (System.Exception ex)
        {
            response.ExceptionMessage = ex.ToString();
        }
    }

    /// <summary>
    /// Execute SQL query to add the user with specified qredentials to the DB 
    /// </summary>
    public void AddUser(UserCredentials request, UserCreationResult response)
    {
        try
        {
            // Add new user to the DB
            string sql = @$"insert into users (login, email, phone_number, password) values ({request.Login}, {request.Email}, {request.PhoneNumber}, {request.Password});";
            // Execute SQL statement 
            // 
            response.IsUserAdded = true;
            response.SignUpGuid = "";
        }
        catch (System.Exception ex)
        {
            response.ExceptionMessage = ex.ToString();
        }
    }

    /// <summary>
    /// Gets if user credentials are correct
    /// </summary>
    public void VerifyUserCredentials(UserCredentials request, VUCResponse response)
    {
        try
        {
            // Get quantity of the users with specified login and password
            string sql = @$"select u.uid qty from users u where u.login = {request.Login} and u.password = {request.Password};";
            // Executes SQL query to get user credentials are correct
            // 
            response.IsVerified = true;
            response.UserUid = "";
        }
        catch (System.Exception ex)
        {
            response.ExceptionMessage = ex.ToString();
        }
    }
}