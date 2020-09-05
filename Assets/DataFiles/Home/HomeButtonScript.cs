using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class HomeButtonScript : MonoBehaviour
{
    public GameObject mute;
    public GameObject unmute;
    public AudioSource audioPlay;

    void Start()
    {
        unmute.SetActive(false);
    }
      public void mutebtn()
    {
        unmute.SetActive(true);
        mute.SetActive(false);
        audioPlay.Pause();
    }
    public void unmutebtn()
    {
        mute.SetActive(true);
        unmute.SetActive(false);
        audioPlay.Play();
    }
    public void exitbtn()
    {
        Application.Quit();
    }
    public void Alpha()
    {
        SceneManager.LoadScene("HomeScene");
    }
    public void Biology()
    {
        SceneManager.LoadScene("UnderwaterScene");
    }
    public void Geography()
    {
        SceneManager.LoadScene("GeographyHome");
    }
     public void Portal()
    {
        SceneManager.LoadScene("ChoosePortal");
    }

}
