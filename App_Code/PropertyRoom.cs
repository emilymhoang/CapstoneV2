using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PropertyRoom
/// </summary>
public class PropertyRoom
{
    public static List<PropertyRoom> listPropertyRoom = new List<PropertyRoom>();
    public int propertyID { get; private set; }
    public int roomID { get; private set; }
    public int tenantID { get; private set; }
    public string monthlyPrice { get; private set; }
    public String squareFootage { get; private set; }
    public String availability { get; private set; }
    public String briefDescription { get; private set; }
    public String lastUpdatedBy { get; private set; }
    public String lastUpdated { get; private set; }
    public String roomDescription { get; private set; }
    public string roomimage1 { get; private set; }
    public string roomimage2 { get; private set; }
    public string roomimage3 { get; private set; }


    public PropertyRoom(int propertyID, string monthlyPrice, String squareFootage,
        String availability, String briefDescription, String roomDescription, string roomimage1, string roomimage2, string roomimage3)
    {
        this.monthlyPrice = "$" + monthlyPrice + "/Month";
        this.squareFootage = squareFootage;
        this.availability = availability;
        this.briefDescription = briefDescription;
        this.propertyID = propertyID;
        this.roomDescription = roomDescription;
        this.roomimage1 = roomimage1;
        this.roomimage2 = roomimage2;
        this.roomimage3 = roomimage3;

    }

    }