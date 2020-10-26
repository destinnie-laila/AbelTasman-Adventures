using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeToGame : MonoBehaviour
{

    public string SceneName;

    public void toGame()
        {
            SceneManager.LoadScene("StartStory");
        }
    

 
}
