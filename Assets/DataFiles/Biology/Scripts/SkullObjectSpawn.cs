using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(ARRaycastManager))]
public class SkullObjectSpawn : MonoBehaviour
{
   

    private ARRaycastManager raycastManager;
    private List<GameObject> placedPrefabList = new List<GameObject>();
    private Vector2 touchPosition =default;
    private bool onTouchHold = false;
    private int placedPrefabCount=0;
    private bool animPlayed=false;
    private Animation anim;
    private GameObject label;

    [SerializeField]
    private int maxPrefabSpawnCount = 0;

    [SerializeField]
    private GameObject SliderParent;

    [SerializeField]
    private Camera arCamera;

    [Tooltip("The UI Text element used to display plane detection messages.")]
    [SerializeField]
    Text m_ToggleEnableAnimText;

        /// <summary>
        /// The UI Text element used to display plane detection messages.
        /// </summary>
        public Text toggleEnableAnimText
        {
            get { return m_ToggleEnableAnimText; }
            set { m_ToggleEnableAnimText = value; }
        }

    [SerializeField]
    [Tooltip("Instantiates this prefab on a plane at the touch location.")]
    GameObject m_PlacedPrefab;
    
    public GameObject placedPrefab
    {
        get { return m_PlacedPrefab; }
        set { m_PlacedPrefab = value; }
    }

    public GameObject spawnedObject { get; private set; }

    [SerializeField]
    private Slider scaleSlider;

    [SerializeField]
    private bool applyScalingPerObject = false;

    private ARSessionOrigin aRSessionOrigin;

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();


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
            if(spawnedObject == null)
            {
                
                spawnedObject = Instantiate(m_PlacedPrefab, hitPose.position, hitPose.rotation);
                // placedPrefabList.Add(spawnedObject);
                placedPrefabCount++;
              
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

    public void backbtn(){
        SceneManager.LoadScene("SelectionScene");
    }

    IEnumerator waitAnim()
    {
        anim["Take 001"].speed = 1;
        anim.Play();
        yield return new WaitForSeconds(4);
            if(label!=null)
        {
            label.SetActive(true);
        }
    }  

    public void playAnim(){
        if(anim==null)
        {
            anim = spawnedObject.GetComponentInChildren<Animation>();   
        }
        string detectionMessage = "";
        label = spawnedObject.transform.Find("Labelling").gameObject;
        animPlayed=!animPlayed;
        if(animPlayed==true)
        {
            detectionMessage = "Disbale Animation";
            // anim.Rewind();
			
            StartCoroutine(waitAnim());
			// anim["Take 001"].time = anim["Take 001"].length;
        } 
        else
        {
            detectionMessage = "Enable Animation";
            anim["Take 001"].speed = -1;
			// anim["Take 001"].time = anim["Take 001"].length;
			anim.Play("Take 001");
            if(label!=null)
            {
                label.SetActive(false);
            }
        }   
        if (toggleEnableAnimText!=null)
        {
            toggleEnableAnimText.text = detectionMessage;
        }
    }
}
