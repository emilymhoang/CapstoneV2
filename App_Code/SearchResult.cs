using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SearchResult
/// </summary>
public class SearchResult
{
    public static List<SearchResult> lstSearchResults = new List<SearchResult>();
    public string resultName { get; private set; }
    public string resultLocation { get; private set; }
    public string resultDescription { get; private set; }
    public double resultPrice { get; private set; }

    public int resultID { get; private set; }

    public string resultimage1 { get; private set; }
    public string resultimage2 { get; private set; }
    public string resultimage3 { get; private set; }

    public SearchResult(int resultID, string resultName, string resultLocation, string resultDescription, double resultPrice, string resultimage1, string resultimage2, string resultimage3)
    {
        this.resultName = resultName;
        this.resultLocation = resultLocation;
        this.resultDescription = resultDescription;
        this.resultPrice = resultPrice;
        this.resultID = resultID;
        this.resultimage1 = resultimage1;
        this.resultimage2 = resultimage2;
        this.resultimage3 = resultimage3;
    }
}