using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(ARRaycastManager))]
public class QuizSpawn : MonoBehaviour
{
   

    private ARRaycastManager raycastManager;
    private GameObject spawnedObject1;
    private GameObject spawnedObject2;
    private GameObject spawnedObject3;
    private GameObject spawnedObject4;
    public GameObject backbtn;
    public AudioSource clapping;
    [SerializeField]
    private Camera arCamera;
    public GameObject clap;
    [SerializeField]
    private GameObject placeablePrefab1;
    [SerializeField]
    private GameObject placeablePrefab2;
    [SerializeField]
    private GameObject placeablePrefab3;
    [SerializeField]
    private GameObject placeablePrefab4;

    [SerializeField]
    private Slider scaleSlider;

    [SerializeField]
    private bool applyScalingPerObject = false;

    [SerializeField]
    private Text scaleTextValue;

    private ARSessionOrigin aRSessionOrigin;

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        scaleSlider.onValueChanged.AddListener(ScaleChanged);
        clap.SetActive(false);
    }

    private void ScaleChanged(float newValue)
    {
        if(applyScalingPerObject){
            if(spawnedObject1 != null)
            {
                spawnedObject1.transform.localScale = Vector3.one * newValue;
                spawnedObject2.transform.localScale = Vector3.one * newValue;
                spawnedObject3.transform.localScale = Vector3.one * newValue;
                spawnedObject4.transform.localScale = Vector3.one * newValue;
            }
        }
        else 
            aRSessionOrigin.transform.localScale = Vector3.one * newValue;

        // scaleTextValue.text = $"Scale {newValue}";
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if(Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position; 
            
            return true;
        }
        
        touchPosition=default;
        return false;
    }

    private void Update()
    {
       

        IEnumerator Winner()
        {
            clap.SetActive(true);
            clapping.Play();
            yield return new WaitForSeconds(3);
        }
        IEnumerator ScaleObject(GameObject G)
                {
                    float scaleDuration = 1.5f;                                
                    Vector3 actualScale = G.transform.localScale;             
                    Vector3 targetScale = new Vector3 (0f,0f,0f);   
                    for(float t = 0; t < 1; t += Time.deltaTime / scaleDuration )
                    {
                        G.transform.localScale = Vector3.Lerp(actualScale ,targetScale ,t);
                        yield return null;
                    }
                }

        if (!TryGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }
        
        Touch touch = Input.GetTouch(0);

        if(EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            return;

        if (raycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = s_Hits[0].pose;
            if(spawnedObject1 == null)
            {
                spawnedObject1 = Instantiate(placeablePrefab1, hitPose.position, hitPose.rotation);
                spawnedObject2 = Instantiate(placeablePrefab2, hitPose.position, hitPose.rotation);
                spawnedObject3 = Instantiate(placeablePrefab3, hitPose.position, hitPose.rotation);
                spawnedObject4 = Instantiate(placeablePrefab4, hitPose.position, hitPose.rotation);


            }           
        }
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
    
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.name == spawnedObject3.name)
                {
                    StartCoroutine(ScaleObject(spawnedObject3));
                }
                if(hit.collider.gameObject.name == spawnedObject2.name)
                {
                    StartCoroutine(ScaleObject(spawnedObject2));
                }
                if(hit.collider.gameObject.name == spawnedObject1.name)
                {
                     StartCoroutine(Winner());
                }
            }
        }

    }
     
}
