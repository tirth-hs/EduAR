using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class HomeScene : MonoBehaviour
{

    public void learnbtn()
    {
        SceneManager.LoadScene("Scroll");
    }
    public void quizbtn()
    {
        SceneManager.LoadScene("QuizScene");
    }
   
    public void backbtn()
    {
        Application.Quit();
        Debug.Log("Back button pressed");
    }
}
