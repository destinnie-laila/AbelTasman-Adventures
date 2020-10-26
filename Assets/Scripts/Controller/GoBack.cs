using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBack : MonoBehaviour
{


    public string SceneName;


 public void goBack()
    {
        Debug.Log("go back " + SceneName);
        SceneManager.LoadScene(SceneName);
    }

public void goMap()
    {
        SceneManager.LoadScene("Map");
    }

public void goIventory()
    {
        SceneManager.LoadScene("Inventory");
    }

public void goHelp()
    {
        SceneManager.LoadScene("Help");
    }


}
