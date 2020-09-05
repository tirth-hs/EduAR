using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject spawnedObject;
    public Text toggleEnableAnimText;
    private Animation anim;
    private bool animPlayed=false;
    void Start()
    {
        anim = spawnedObject.GetComponent<Animation>();
    }
    public void playAnim(){

        string detectionMessage = "";
        animPlayed=!animPlayed;
        if(animPlayed==true)
        {
            detectionMessage = "Disbale Animation";
            // anim.Rewind();
			
            anim["Take 001"].speed = 1;
            anim.Play();
			// anim["Take 001"].time = anim["Take 001"].length;
        } 
        else
        {
            Debug.Log(anim.name);
            Debug.Log("Enable");
      
            detectionMessage = "Enable Animation";
            anim["Take 001"].speed = -1;
			// anim["Take 001"].time = anim["Take 001"].length;
			anim.Play("Take 001");
        }   
        if (toggleEnableAnimText!=null)
        {
            toggleEnableAnimText.text = detectionMessage;
        }
    }
}
