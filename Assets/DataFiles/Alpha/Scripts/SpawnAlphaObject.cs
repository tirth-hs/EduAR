using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(ARRaycastManager))]
public class SpawnAlphaObject : MonoBehaviour
{
   

    private ARRaycastManager raycastManager;
    private GameObject spawnedObject;

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
        if(spawnedObject == null)
        {
            spawnedObject = Instantiate(placeablePrefab, hitPose.position, hitPose.rotation);
        }
        else
        {
            spawnedObject.transform.position = hitPose.position;
            spawnedObject.transform.rotation = hitPose.rotation;
        }            
        }
    }
     
}
