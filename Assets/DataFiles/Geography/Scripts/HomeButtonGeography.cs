using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class HomeButtonGeography : MonoBehaviour
{
    public void backbtn()
    {
        SceneManager.LoadScene("ExplorePlanets");
    }
    public void planets()
    {
        SceneManager.LoadScene("Planets");
    }
    public void ExplorePlanets()
    {
        SceneManager.LoadScene("ExplorePlanets");
    }

}
