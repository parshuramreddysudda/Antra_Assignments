
namespace ApplicationCore.Constants;

public class Constants
{
    public static readonly string ROLE_ADMIN = "Admin";
    public static readonly string ROLE_MANAGER = "Manager";
    public static readonly string ROLE_EMPLOYEE = "Employee";
    public static readonly string ADD_MANAGER_CLAIM_VALUE = "Add Manager";
    public static readonly string EDIT_MANAGER_CLAIM_VALUE = "Edit Manager";
    public static readonly string DELETE_MANAGER_CLAIM_VALUE = "Delete Manager";
    public static readonly string GET_MANAGER_CLAIM_VALUE = "Get Manager";
    
    public static readonly string ADD_EMPLOYEE_CLAIM_VALUE = "Add Employee";
    public static readonly string EDIT_EMPLOYEE_CLAIM_VALUE = "Edit Employee";
    public static readonly string DELETE_EMPLOYEE_CLAIM_VALUE = "Delete Employee";
    public static readonly string GET_EMPLOYEE_CLAIM_VALUE = "Get Employee";
    public static readonly string ISSUER = "AppClaim";
    public static readonly string AUDIENCE = "AppClaim";
    public static readonly string JSON_SECRET_KEY = "ThisisJSONSECRETKEYWOTHSOMERANDOMSTRINGFORSECURITY";
    
    //Order Service Constants
    public static readonly string ORDER_QUEUE_HOST_NAME = "localhost";
    public static readonly string ORDER_QUEUE_USER_NAME = "guest";
    public static readonly string ORDER_QUEUE_PASSWORD = "guest";
    public static readonly string ORDER_QUEUE_NAME = "orderservice";

}