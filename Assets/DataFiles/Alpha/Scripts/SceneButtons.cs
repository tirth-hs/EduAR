using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SceneButtons : MonoBehaviour
{
    public GameObject next;
    public GameObject previous;
    public GameObject marker;
    public AudioSource audioPlay;

    void Start()
    {
         if(SceneManager.GetActiveScene().name == "AScene")
        {
            previous.SetActive(false);
        }
        else if(SceneManager.GetActiveScene().name == "ZScene")
        {
            next.SetActive(false);
        }
    }

    void Update()
    {
        if(Input.touchCount>0)
        {
            marker.SetActive(false);
            audioPlay.PlayDelayed(1);
        }
        if(Input.GetMouseButtonDown(0))
        {
            marker.SetActive(false);
            audioPlay.PlayDelayed(1);
        }
    }

    public void backbtn()
    {
        if(SceneManager.GetActiveScene().name == "QuizScene")
        {
            SceneManager.LoadScene("HomeScene");
        }
        else
        {
            SceneManager.LoadScene("Scroll");
        }
        
    }

    public void restartbtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public void nextbtn()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        char[] charArr = currentSceneName.ToCharArray(); 
        ++charArr[0];
        string NextSceneName = new string(charArr);
        SceneManager.LoadScene(NextSceneName);
        
    }

    public void previoubtn()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        char[] charArr = currentSceneName.ToCharArray(); 
        --charArr[0];
        string PreviousSceneName = new string(charArr);
        SceneManager.LoadScene(PreviousSceneName);
    }
}
