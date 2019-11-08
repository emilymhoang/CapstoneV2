using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Favorite
/// </summary>
public class Favorite
{
    public static List<Favorite> lstFavorites = new List<Favorite>();
    public string favName { get; private set; }
    public string favLocation { get; private set; }
    public string favDescription { get; private set; }
    public double favPrice { get; private set; }

    public Favorite(string favName, string favLocation, string favDescription, double favPrice)
    {
        this.favName = favName;
        this.favLocation = favLocation;
        this.favDescription = favDescription;
        this.favPrice = favPrice;
    }
}