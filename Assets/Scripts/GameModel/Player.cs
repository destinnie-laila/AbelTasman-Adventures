using UnityEngine;
using System.Collections;
using SQLite4Unity3d;

public class Player 
{

    private string name;
   // private Location location;
    private int health;
    private int wealth;
    private string password;
    private int playerID;
    private int locationID;

    // what about inventory?

    [AutoIncrement, PrimaryKey]

    public int PlayerID { get => playerID; set => playerID = value; }
    public string Name { get => name; set => name = value; }
    public int Health { get => health; set => health = value; }
    public int Wealth { get => wealth; set => wealth = value; }
    public string Password { get => password; set => password = value; }
    public int LocationID { get => locationID; set => locationID = value; }

    public void changeLocale (Location location)
    {
        locationID = location.Id;
        GameModel.ds.updatePlayer(this);
    }
}
