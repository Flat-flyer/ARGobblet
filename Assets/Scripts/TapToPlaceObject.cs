using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class TapToPlaceObject : MonoBehaviour
{
    public GameObject objectToSpawn;
    GameObject spawnedObject;
    ARRaycastManager arRaycastManager;
    Vector2 touchPosition;
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    bool GetTouchPosition(out Vector2 touchPosition)
    {
        if (/*Input.touchCount > 0 &&*/ Input.GetMouseButtonDown(0))
        {
            //touchPosition = Input.GetTouch(0).position;
            print("yes");
            touchPosition = Input.mousePosition;
            return true;
        }
        print("sadly no");
        touchPosition = default;
        return false;
    }
    // Update is called once per frame
    void Update()
    {
        // Check to see if there was no Touch event on Screen
        if (!GetTouchPosition(out Vector2 touchPosition))
            return;
        // Touch event occured
        if (arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;
            if (spawnedObject == null)
            {
                spawnedObject = Instantiate(objectToSpawn, hitPose.position,
                hitPose.rotation);
            }
         
        }
    }
 }
