using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Homeowner
{
    public int HomeownerID { get; private set; }
    public String email { get; private set; }
    public String phoneNumber { get; private set; }
    public String firstName { get; private set; }
    public String lastName { get; private set; }

    public String middleName;
    public String dateOfBirth { get; private set; }
    public String password { get; private set; }
    public String gender { get; private set; }
    public String lastUpdatedBy { get; private set; }
    public String lastUpdated { get; private set; }
    public String backgroundCheckDate { get; private set; }
    public String backgroundCheckResult { get; private set; }
    public int propertyID { get; private set; }
    public String userName { get; private set; }
    public String confirmPassword { get; private set; }



    public Homeowner(String firstName, String lastName, String gender, String dateOfBirth, String email, String phoneNumber)
    {
        this.email = email;
        this.phoneNumber = phoneNumber;
        this.firstName = firstName;
        this.lastName = lastName;
        this.dateOfBirth = dateOfBirth;
        this.gender = gender;
        setMiddleName(middleName);
    }

    public Homeowner(String userName, String password, String confirmPassword)
    {
        this.userName = userName;
        this.password = password;
        this.confirmPassword = confirmPassword;
    }
    public Homeowner(String firstName, String lastName, String gender, String dateOfBirth, String email, String phoneNumber, String userName, String password, String confirmPassword)
    {
        this.email = email;
        this.phoneNumber = phoneNumber;
        this.firstName = firstName;
        this.lastName = lastName;
        this.dateOfBirth = dateOfBirth;
        this.gender = gender;
        setMiddleName(middleName);
        this.userName = userName;
        this.password = password;
        this.confirmPassword = confirmPassword;
    }
    public void setMiddleName(String middleName) { this.middleName = middleName; }

    public String getMiddleName() { return this.middleName; }


}