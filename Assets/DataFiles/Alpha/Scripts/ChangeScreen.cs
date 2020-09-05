using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class ChangeScreen : MonoBehaviour
{

    public void onpress(){
        string name = EventSystem.current.currentSelectedGameObject.name;
        SceneManager.LoadScene(name+"Scene");
                
    }
    public void backbtn(){
        SceneManager.LoadScene("HomeScene");
    }
    public void restartbtn(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}