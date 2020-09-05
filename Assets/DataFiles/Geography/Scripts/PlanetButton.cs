using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlanetButton : MonoBehaviour
{
    public GameObject marker;

    void Update()
    {
        if(Input.touchCount>0)
        {
            marker.SetActive(false);
        }
        if(Input.GetMouseButtonDown(0))
        {
            marker.SetActive(false);
        }
    }

    public void backbtn()
    {
        SceneManager.LoadScene("GeographyHome");
    }

    public void restartbtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

}

