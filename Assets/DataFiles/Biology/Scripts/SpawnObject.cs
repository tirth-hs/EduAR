using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


[RequireComponent(typeof(ARRaycastManager))]
public class SpawnObject : MonoBehaviour
{
   

    private ARRaycastManager raycastManager;
    private GameObject spawnedObject;
    private List<GameObject> placedPrefabList = new List<GameObject>();
    private Vector2 touchPosition =default;
    private bool onTouchHold = false;
    private int placedPrefabCount=0;
    private GameObject label;
    private bool displayText=false;
    

    [SerializeField]
    private int maxPrefabSpawnCount = 0;

    [SerializeField]
    private GameObject SliderParent;

    [SerializeField]
    private Camera arCamera;
    
    [SerializeField]
    private GameObject placeablePrefab;

    [SerializeField]
    private Slider scaleSlider;

    [SerializeField]
    private bool applyScalingPerObject = false;

    [SerializeField]
    private Text scaleTextValue;

    [SerializeField]
    private Text toggleDisplayText;

    [SerializeField]
    private GameObject DescriptionButton;

    [SerializeField]
    private GameObject SpecialButton;

    private ARSessionOrigin aRSessionOrigin;

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    void Start()
    {
        SliderParent.SetActive(false);
        DescriptionButton.SetActive(false);
        SpecialButton.SetActive(false);
    }

    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        scaleSlider.onValueChanged.AddListener(ScaleChanged);
    }

    private void ScaleChanged(float newValue)
    {
        if(applyScalingPerObject){
            if(spawnedObject != null)
            {
                spawnedObject.transform.localScale = Vector3.one * newValue;
            }
        }
        else 
            aRSessionOrigin.transform.localScale = Vector3.one * newValue;

        // scaleTextValue.text = $"Scale {newValue}";
    }

    // bool TryGetTouchPosition(out Vector2 touchPosition)
    // {
    //     if(Input.GetTouch(0).phase == TouchPhase.Began)
    //     {
    //         touchPosition = Input.GetTouch(0).position;
            
    //         return true;
    //     }

    //     if(Input.GetTouch(0).phase == TouchPhase.Ended)
    //     {
    //         onTouchHold =false;
    //     }
    //     touchPosition=default;
    //     return false;
    // }

    private void Update()
    {
       
        // if (!TryGetTouchPosition(out Vector2 touchPosition))
        // {
        //     return;
        // }
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                return;

            touchPosition = touch.position;

            if(touch.phase == TouchPhase.Began)
            {

                Ray ray = arCamera.ScreenPointToRay(touch.position);
                RaycastHit hitObject;
                if(Physics.Raycast(ray, out hitObject))
                {
                    if(hitObject.transform.name.Contains(spawnedObject.name))
                    {
                        onTouchHold = true;
                    }
                }
               
            }

            if (touch.phase == TouchPhase.Ended)
            {
                onTouchHold = false;
            }

        }


        if (raycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = s_Hits[0].pose;
            if(placedPrefabCount<maxPrefabSpawnCount)
            {
                
                spawnedObject = Instantiate(placeablePrefab, hitPose.position, hitPose.rotation);
                label = spawnedObject.transform.Find("Labelling").gameObject;
                if (label!=null)
                {
                    label.SetActive(false);
                }
                SliderParent.SetActive(true);
                DescriptionButton.SetActive(true);
                SpecialButton.SetActive(true);
                // placedPrefabList.Add(spawnedObject);
                placedPrefabCount++;
            }
            else
            {
                if(spawnedObject!=placeablePrefab)
                {
                    Destroy(spawnedObject);
                    spawnedObject = Instantiate(placeablePrefab, hitPose.position, hitPose.rotation);
                    // spawnedObject.transform.GetChild(1).gameObject.SetActive(false);
                    label = spawnedObject.transform.Find("Labelling").gameObject;
                    SliderParent.SetActive(true);
                    DescriptionButton.SetActive(true);
                    SpecialButton.SetActive(true);
                    if (label!=null)
                    {
                        label.SetActive(false);
                    }
                }
                else
                {
                    if(onTouchHold)
                    {
                        spawnedObject.transform.position = hitPose.position;
                        spawnedObject.transform.rotation = hitPose.rotation;
                    }

                }
            }            
        }
     
    }

    public void SetPrefabType(GameObject prefabType)
    {
        SliderParent.SetActive(false);
        DescriptionButton.SetActive(false);
        SpecialButton.SetActive(false);
        placeablePrefab = prefabType;
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("SkullScene");
    }

    public void DisplayButton()
    {
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
    public void backbtn()
    {
        SceneManager.LoadScene("BioHome");
    }

}
