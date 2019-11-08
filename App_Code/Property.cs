using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Property
{
    public static List<Property> lstPropertySearchResults = new List<Property>();
    public static List<Property> lstFavorites = new List<Property>();

    public int propertyID { get; private set; }
    public int houseNumber { get; private set; }
    public String street { get; private set; }
    public String cityCounty { get; private set; }
    public String homeState { get; private set; }
    public String country { get; private set; }
    public int zip { get; private set; }
    public double priceRange { get; private set; }
    public int numberOfRooms { get; private set; }
    public int availability { get; private set; }
    public String lastUpdatedBy { get; private set; }
    public String lastUpdated { get; private set; }
    public int hostID { get; private set; }

    public Property(int houseNumber, String street,
        String cityCounty, String homeState, String country, int zip,
        double priceRange, int numberOfRooms, int availability, int hostID)
    {
        this.houseNumber = houseNumber;
        this.street = street;
        this.cityCounty = cityCounty;
        this.homeState = homeState;
        this.country = country;
        this.zip = zip;
        this.priceRange = priceRange;
        this.numberOfRooms = numberOfRooms;
        this.availability = availability;
        this.hostID = hostID;
    }

    public Property(int houseNumber, String street,
        String cityCounty, String homeState, String country, int zip)
    {
        this.houseNumber = houseNumber;
        this.street = street;
        this.cityCounty = cityCounty;
        this.homeState = homeState;
        this.country = country;
        this.zip = zip;

    }
}