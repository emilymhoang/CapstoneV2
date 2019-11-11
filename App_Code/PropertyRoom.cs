using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PropertyRoom
/// </summary>
public class PropertyRoom
{
    public int propertyID { get; private set; }
    public int roomID { get; private set; }
    public int tenantID { get; private set; }
    public double monthlyPrice { get; private set; }
    public int squareFootage { get; private set; }
    public String availability { get; private set; }
    public String briefDescription { get; private set; }
    public String lastUpdatedBy { get; private set; }
    public String lastUpdated { get; private set; }
    public String roomDescription { get; private set; }


    public PropertyRoom(int propertyID, double monthlyPrice, int squareFootage,
        String availability, String briefDescription, String roomDescription)
    {
        this.monthlyPrice = monthlyPrice;
        this.squareFootage = squareFootage;
        this.availability = availability;
        this.briefDescription = briefDescription;
        this.propertyID = propertyID;
        this.tenantID = 2;
        this.roomDescription = roomDescription;

    }
}