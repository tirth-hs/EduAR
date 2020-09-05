using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class GoToScene : MonoBehaviour
{
    public void backbtn()
    {
        SceneManager.LoadScene("StartSCreen");
    }
    public void beach()
    {
        SceneManager.LoadScene("BeachScene");
    }
    public void underwater()
    {
        SceneManager.LoadScene("UnderwaterScene");
    }
    public void northenlights()
    {
        SceneManager.LoadScene("NorthernLights");
    }
    public void scenebackbtn()
    {
        SceneManager.LoadScene("ChoosePortal");
    }

}
