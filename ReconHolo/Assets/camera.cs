using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class camera : MonoBehaviour {

    public Transform cameraTf;
    public Transform targetTf;
    
    //Demo target location
    const float lat = 32.0876979f;
    const float logi = 34.7839517f;
    const float altitude = 21;

    /// <summary>
    ///     Calculats target location relative to cameraPosition
    /// </summary>
    /// <param name="cameraPosition"></param>
    /// <param name="distance">Distance from camera</param>
    /// <param name="v">V degrees in the vertical plane</param>
    /// <param name="h">H degrees in the horizontal plane</param>
    public Vector3 calculateTargetLocation(Vector3 cameraPosition, float distance, float v, float h)
    {
        Vector3 vTarget = Quaternion.Euler(v, h, 0) * -Vector3.forward;
        return cameraPosition - vTarget * distance;
    }

    // Use this for initialization
    void Start () {
        //V degrees in the vertical plane and 
        float V = 45;// + deflection
        //H degrees in the horizontal plane
        float H = 45;// + deflection
        //distance from the camera
        float distance = 2; 
        
        targetTf.position = calculateTargetLocation(cameraTf.position, distance, V, H);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
