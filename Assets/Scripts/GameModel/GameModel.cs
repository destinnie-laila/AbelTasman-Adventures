using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using System.IO;



using System.Text;
using SQLite4Unity3d;


// Is this a factory?

public static class GameModel
{

    static String _name;
    public static bool Started = false;

    public static string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }

    }



    public static Location currentLocale;
    public static Player currentPlayer;
    public static Location startLocation;



    // == My new database being created on load

    public static DataService ds = new DataService("AdventureTasmanDB.db");



    // ======= The password function variable



    public enum PasswdMode
    {
        NeedName,
        NeedPassword,
        OK,
        AllBad
    }



    // ===== This is checing the password to make sure that the name and password exist
    // ==== will need to put in a string check to make sure that a password is needed



    public static PasswdMode CheckPassword(string pName, string pPassword)
    {
        PasswdMode result = GameModel.PasswdMode.AllBad;

        Player aPlayer = ds.getPlayer(pName);
        if (aPlayer != null)
        {
            if (aPlayer.Password == pPassword)
            {
                result = GameModel.PasswdMode.OK;
                GameModel.currentPlayer = aPlayer; // << WATCHOUT THIS IS A SIDE EFFECT
                GameModel.currentLocale = GameModel.ds.GetPlayerLocation(GameModel.currentPlayer);
            }
            else
            {
                result = GameModel.PasswdMode.NeedPassword;
            }
        }
        else
            result = GameModel.PasswdMode.NeedName;

        return result;
    }


    // ==== Register a player on click



    public static void RegisterPlayer(string pName, string pPassword)
    {

        GameModel.currentPlayer = GameModel.ds.storeNewPlayer(pName, pPassword, GameModel.ds.GetFirstLocation().Id, 100, 200);
    }





    // ======== creating database ===



    public static void SetupGame()

    {
        ds.CreateDB();

    }







    public static void MakeGame()

    {
        if (!ds.HaveLocations())

        {
            Location Lost, BarkBay;

            currentLocale = new Location

            {
                Name = "Lost!!",
                Story = "You have been Walking for days and lost your way through the great Abel Tasman, You Are thirsty and cold you realise its about to get dark and you must make a move! What would you like to do? " +
                "HINT: TYPE HELP FOR A COMMAND MENU"
            };

            Lost = currentLocale;
            ds.storeNewLocation(Lost.Name, Lost.Story);

            Lost.addLocation("North", "Rain!!", "It has just started raining and you have to find cover quickly. You know that you must keep moving! Where will you go?");
            Lost.addLocation("South", "Swamp!!", "Oh no you have just landed in a swamp you quickly scrape your way to through the sludge. You manage to get out but you need to eat after all that hard work!");

            BarkBay = Lost.getLocation("North");
            BarkBay.addLocation("South", Lost);

        }

        else

        {

            currentLocale = ds.GetFirstLocation();
            
        }

    }

}



