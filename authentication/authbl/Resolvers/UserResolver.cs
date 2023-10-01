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
            if (response == null)
                response = new UserExistance();
            string sql = @$"-- 
select 'login' as credentials_type, count(c.*) as qty from delivery_customer c where c.login = '{request.Login}'
union 
select 'email' as credentials_type, count(c.*) as qty from delivery_customer c where c.email = '{request.Email}'
union
select 'phone_number' as credentials_type, count(c.*) as qty from delivery_customer c where c.phone_number = '{request.PhoneNumber}'
;";
            var dt = new PgDbConnection(ConnectionString).ExecuteSqlCommand(sql);
            foreach(DataRow row in dt.Rows)
            {
                if (row["credentials_type"].ToString() == "login")
                    response.LoginExists = row["qty"].ToString() != "0";
                if (row["credentials_type"].ToString() == "email")
                    response.EmailExists = row["qty"].ToString() != "0";
                if (row["credentials_type"].ToString() == "phone_number")
                    response.PhoneNumberExists = row["qty"].ToString() != "0";
            }
        }
        catch (System.Exception ex)
        {
            response.ExceptionMessage = ex.ToString();
        }
    }

    /// <summary>
    /// Execute SQL query to add the user with specified qredentials to the DB.
    /// </summary>
    public void AddUser(UserCredentials request, UserCreationResult response)
    {
        try
        {
            if (response == null)
                response = new UserCreationResult();
            string sql = @$"insert into delivery_customer (login, email, phone_number, password) values ('{request.Login}', '{request.Email}', '{request.PhoneNumber}', '{request.Password}');";
            new PgDbConnection(ConnectionString).ExecuteSqlCommand(sql);
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
            if (response == null)
                response = new VUCResponse();
            string sql = @$"select count(*) as qty from delivery_customer c where c.login = '{request.Login}' and c.password = '{request.Password}';";
            var dt = new PgDbConnection(ConnectionString).ExecuteSqlCommand(sql);
            foreach(DataRow row in dt.Rows)
            {
                if (row["qty"].ToString() != "0" && row["qty"].ToString() != "1")
                    throw new System.Exception("CRITICAL ERROR: more than one customer with the same name");
                response.IsVerified = row["qty"].ToString() == "1";
            }
        }
        catch (System.Exception ex)
        {
            response.ExceptionMessage = ex.ToString();
        }
    }
}