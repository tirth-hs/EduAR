using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class BioHomeButtonScript : MonoBehaviour
{
    
    public void learnbtn()
    {
        SceneManager.LoadScene("SelectionScene");
    }
    public void quizbtn()
    {
        SceneManager.LoadScene("SelectionScene");
    }
   
    public void backbtn()
    {
        SceneManager.LoadScene("StartSCreen");
    }
}

