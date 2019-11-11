using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class BadgeProperty
{
    public int RoomID { get; private set; }
    public string privateEntrance { get; private set; }
    public string attached { get; private set; }
    public string kitchen { get; private set; }
    public string privateBathroom { get; private set; }
    public string furnished { get; private set; }
    public string closetSpace{ get; private set; }
    public string nonSmoker { get; private set; }

    public BadgeProperty(int RoomID, string privateEntrance, string attached, string kitchen, string privateBathroom, string furnished, string closetSpace, string nonSmoker)
    {
        this.RoomID = RoomID;
        this.privateEntrance = privateEntrance;
        this.attached = attached;
        this.kitchen = kitchen;
        this.privateBathroom = privateBathroom;
        this.furnished = furnished;
        this.closetSpace = closetSpace;
        this.nonSmoker = nonSmoker;

    }
}