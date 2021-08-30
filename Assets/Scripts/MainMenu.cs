using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Material trapMat;
    public Material goalMat;
    public Toggle colorblindMode;


    public void PlayMaze()
    {

        if (colorblindMode.isOn == true)
        {
            trapMat.color = new Color32(255, 112, 0, 1);
            goalMat.color = Color.blue;
            colorblindMode.isOn = true;
        }
        else
        {
            trapMat.color = Color.red;
            goalMat.color = Color.green;
            
        }

        SceneManager.LoadScene("maze");
        //could also access scene via index with something like
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitMaze()
    {
        Debug.Log("Quit Game");
    }
    
   
}
