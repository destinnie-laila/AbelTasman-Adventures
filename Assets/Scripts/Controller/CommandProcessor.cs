using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using System.IO;

public class CommandProcessor


{
    //Constructor

		public CommandProcessor ()
		{

		}
        
        
		public String Parse(String pCmdStr)

    {


			String strResult = "Do not understand";; //If a wrong command is input you will get do not understand
			pCmdStr = pCmdStr.ToLower(); // Converts input text to Lowercase letters
			String[] parts = pCmdStr.Split(' '); // tokenise the command
            Location nextLocale; //Variable to move to next location



        if (parts.Length > 0)

        {

            // process the tokens
            switch (parts[0])
            {

                case "inventory":


                    SceneManager.LoadScene("Inventory"); Debug.Log("inventory");


                    break;




                case "map":
                    


                     SceneManager.LoadScene("Map"); Debug.Log("Map");


                    break;


                case "help":



                    SceneManager.LoadScene("Help"); Debug.Log("Help");


                    break;






                case "go":


                    // =============== Go North Story ==================== //



                    switch (parts[1])
                    {
                        case "north":

                            Debug.Log("Got go North");

                            nextLocale = GameModel.currentLocale.getLocation("North");

                            if (nextLocale == null)
                                strResult = "Sorry can't go North ";

                            else
                            {
                                GameModel.currentLocale = nextLocale;
                           
                                GameModel.currentPlayer.changeLocale(nextLocale);
                                strResult = GameModel.currentLocale.Name + " " + GameModel.currentLocale.Story;
                            }

                            break;



                        // ================== Go South Story ========================= (south only works when your at StartStory) //

                        case "south":

                            Debug.Log("Got go South");

                            nextLocale = GameModel.currentLocale.getLocation("South");

                            if (nextLocale == null)

                                strResult = "Sorry can't go South ";

                            else

                            {
                                GameModel.currentLocale = nextLocale;
                              
                                GameModel.currentPlayer.changeLocale(nextLocale);
                                strResult = GameModel.currentLocale.Name + " " + GameModel.currentLocale.Story;
                            }


                            //strResult = "Got Go South";

                            break;


                        // ================== Default statement if no switch case works  ========================= //

                        default:
                            Debug.Log(" do not know how to go there");
                            strResult = "Do not know how to go there";
                            break;



                    }
                    // end switch


                    break;


                default:
                    Debug.Log("Do not understand");
                    strResult = "Do not understand";
                    break;
            



                }// end switch


            }//end if


            else
            {
                Debug.Log("Do not understand");
                strResult = "Do not understand";
            }


                    return strResult;



		} // Parse



}


