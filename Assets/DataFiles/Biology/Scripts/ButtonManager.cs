using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject spawnedObject;
    public Text toggleDisplayText;
    private bool displayText=false;
    private GameObject label;

    // private Animation anim;
    // private bool animPlayed=false;
    void Start()
    {
        // anim = spawnedObject.GetComponent<Animation>();
        label = spawnedObject.transform.Find("Labelling").gameObject;
        label.SetActive(false);
    }
    // public void playAnim(){

    //     string detectionMessage = "";
    //     animPlayed=!animPlayed;
    //     if(animPlayed==true)
    //     {
    //         detectionMessage = "Disbale Animation";
    //         // anim.Rewind();
			
    //         anim["Take 001"].speed = 1;
    //         anim.Play();
	// 		// anim["Take 001"].time = anim["Take 001"].length;
    //     } 
    //     else
    //     {
    //         Debug.Log(anim.name);
    //         Debug.Log("Enable");
      
    //         detectionMessage = "Enable Animation";
    //         anim["Take 001"].speed = -1;
	// 		// anim["Take 001"].time = anim["Take 001"].length;
	// 		anim.Play("Take 001");
    //     }   
    //     if (toggleEnableAnimText!=null)
    //     {
    //         toggleEnableAnimText.text = detectionMessage;
    //     }
    // }

    public void DisplayButton(){
        string detectionMessage = "";
        
        if (label!=null)
        {
            displayText = !displayText;
            if(displayText==true)
            {
                detectionMessage = "Hide Parts";
                label.SetActive(true);
            } 
            else
            {
                detectionMessage = "Show Parts";
                label.SetActive(false);
            }   
            if (toggleDisplayText!=null)
            {
                toggleDisplayText.text = detectionMessage;
            }
        }
       
    }
}
