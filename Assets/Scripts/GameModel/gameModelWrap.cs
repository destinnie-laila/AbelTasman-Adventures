using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameModelWrap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()

    {
        if (GameModel.Started == false)
        {

            GameModel.Name = "Abel Tasman Adventures";
            GameModel.SetupGame();
            GameModel.MakeGame();
           
            GameModel.Started = true;

        }
    }

   
}
