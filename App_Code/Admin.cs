using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Admin
/// </summary>
public class Admin
{
    public int adminID { get; private set; }
    public string firstName { get; private set; }
    public string lastName { get; private set; }
    public string userName { get; private set; }
    public string password { get; private set; }
    public string confirmPassword { get; private set; }
    public Admin()
    {
        
    }

    public Admin(int adminID, string firstName, string lastName, string username, string password, string confirmPassword)
    {
        this.adminID = adminID;
        this.firstName = firstName;
        this.lastName = lastName;
        this.userName = userName;
        this.password = password;
        this.confirmPassword = confirmPassword;
    }
}