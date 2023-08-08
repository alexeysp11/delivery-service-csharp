using System.Data;
using Cims.WorkflowLib.DbConnections;
using DeliveryService.Models;

namespace DeliveryService.Authentication.AuthBL;

public class TokenHelper
{
    private PgDbConnection PgDbConnection { get; }
    private int HoursToAdd { get; }
    private string ConnectionString { get; }

    public TokenHelper()
    {
        ConnectionString = "Server=127.0.0.1;Port=5432;Userid=postgres;Password=postgres;Database=postgres";
        PgDbConnection = new PgDbConnection(ConnectionString);
        HoursToAdd = 5;
    }

    /// <summary>
    /// 
    /// </summary>
    public SessionTokenInfo CreateToken()
    {
        // Assign all the necessary parameters
        var guid = System.Guid.NewGuid(); 
        var dt1 = System.DateTime.Now;
        var dt2 = dt1.AddHours(HoursToAdd);
        // Add or modify guid in the database
        PgDbConnection.ExecuteSqlCommand(@$"
insert into public.deliveryservice_auth_token(session_token_guid,begin_datetime,end_datetime)
values ('{guid}','{dt1}','{dt2}');");
        // 
        return new SessionTokenInfo
        {
            SessionTokenGuid = guid,
            TokenActivityBegin = dt1,
            TokenActivityEnd = dt2
        }; 
    }
    /// <summary>
    /// 
    /// </summary>
    public SessionTokenInfo GetTokenByGuid(System.Guid guid)
    {
        var dataTable = PgDbConnection.ExecuteSqlCommand(@$"
select
	at.deliveryservice_auth_token_id,
	at.session_token_guid,
	at.begin_datetime,
	at.end_datetime
from public.deliveryservice_auth_token at
where at.session_token_guid = '{guid}';");
        // TODO: check the number of rows and columns' names
        // for example, the number of rows is correct if only one record was returned
        var dt1 = (System.DateTime)dataTable.Rows[0][2];
        var dt2 = (System.DateTime)dataTable.Rows[0][3];
        return new SessionTokenInfo
        {
            SessionTokenGuid = guid,
            TokenActivityBegin = dt1,
            TokenActivityEnd = dt2
        }; 
    }
}
