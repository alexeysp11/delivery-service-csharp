using System.Data;
using WorkflowLib.DbConnections;
using WokflowLib.Authentication.Models;
using WokflowLib.Authentication.Models.NetworkParameters;
using WorkflowLib.Models.ErrorHandling;

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
select 'login' as credentials_type, count(c.*) as qty from delivery_customer_cb c where c.login = '{request.Login}'
union 
select 'email' as credentials_type, count(c.*) as qty from delivery_customer_cb c where c.email = '{request.Email}'
union
select 'phone_number' as credentials_type, count(c.*) as qty from delivery_customer_cb c where c.phone_number = '{request.PhoneNumber}'
;";
            var dt = new PgDbConnection(ConnectionString).ExecuteSqlCommand(sql).DataTableResult;
            foreach (DataRow row in dt.Rows)
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
            response.WorkflowException = new WorkflowException
            {
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                FullMessage = ex.ToString()
            };
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
            string sql = @$"-- 
insert into delivery_customer_cb (login, email, phone_number, password, customer_uid) 
values ('{request.Login}', '{request.Email}', '{request.PhoneNumber}', '{request.Password}', '{System.Guid.NewGuid().ToString()}');";
            new PgDbConnection(ConnectionString).ExecuteSqlCommand(sql);
            response.IsUserAdded = true;
            response.SignUpGuid = "";
        }
        catch (System.Exception ex)
        {
            response.WorkflowException = new WorkflowException
            {
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                FullMessage = ex.ToString()
            };
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
            string sql = @$"--
select 
	c.customer_uid, 
	c.email, 
	c.phone_number
from delivery_customer_cb c
where c.login = '{request.Login}' and c.password = '{request.Password}'
;";
            var dt = new PgDbConnection(ConnectionString).ExecuteSqlCommand(sql).DataTableResult;
            if (dt.Rows.Count > 1)
                throw new System.Exception("CRITICAL ERROR: more than one customer with the same name");
            foreach (DataRow row in dt.Rows)
            {
                string userUid = string.Empty;
                if (row["customer_uid"] == null || string.IsNullOrWhiteSpace(userUid = row["customer_uid"].ToString()))
                    throw new System.Exception("CRITICAL ERROR: user UID could not be null or empty");
                response.UserUid = userUid;
                response.UserCredentials = new UserCredentials 
                {
                    Email = row["email"].ToString(),
                    PhoneNumber = row["phone_number"].ToString()
                };
                response.IsVerified = true;
            }
        }
        catch (System.Exception ex)
        {
            response.WorkflowException = new WorkflowException
            {
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                FullMessage = ex.ToString()
            };
        }
    }

    public int GetUserIdByUid(string uid)
    {
        int result = -1;
        try
        {
            if (string.IsNullOrWhiteSpace(uid))
                throw new System.Exception("User UID could not be null or empty");
            string sql = @$"select c.delivery_customer_cb_id from delivery_customer_cb c where c.customer_uid = '{uid}';";
            var dt = new PgDbConnection(ConnectionString).ExecuteSqlCommand(sql).DataTableResult;
            if (dt.Rows.Count > 1)
                throw new System.Exception("CRITICAL ERROR: more than one customer with the same UID");
            foreach (DataRow row in dt.Rows)
            {
                result = Convert.ToInt32(row["delivery_customer_cb_id"]);
            }
            return result;
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}