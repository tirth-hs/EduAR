using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PlanetInfo : MonoBehaviour
{
    public void backbtn()
    {
        SceneManager.LoadScene("ExplorePlanets");
    }
    public void restartbtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void exploreBackbtn()
    {
        SceneManager.LoadScene("GeographyHome");
    }
    public void mars()
    {
        SceneManager.LoadScene("Mars");
    }
    public void earth()
    {
        SceneManager.LoadScene("Earth");
    }
}
