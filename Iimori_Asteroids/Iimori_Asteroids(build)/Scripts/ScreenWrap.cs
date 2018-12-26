using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour {

    // Use this for initialization
    // Use this for initialization
    public Camera cam;
    public GameObject gObject;
    float totalCamHeight;
    float totalCamWidth;

    void Start()
    {
        cam = Camera.main;
        totalCamHeight = cam.orthographicSize * 2f;
        totalCamWidth = totalCamHeight * cam.aspect;
        //Debug.Log(totalCamHeight);
    }

    // Update is called once per frame
    void Update()
    {
        if (gObject.transform.position.y > totalCamHeight / 2)
        {
            gObject.transform.position = new Vector3(gObject.transform.position.x, -totalCamHeight / 2);
        }
        if (gObject.transform.position.y < -totalCamHeight / 2)
        {
            gObject.transform.position = new Vector3(gObject.transform.position.x, totalCamHeight / 2);
        }
        if (gObject.transform.position.x > totalCamWidth / 2)
        {
            gObject.transform.position = new Vector3(-totalCamWidth / 2, gObject.transform.position.y);
        }
        if (gObject.transform.position.x < -totalCamWidth / 2)
        {
            gObject.transform.position = new Vector3(totalCamWidth / 2, gObject.transform.position.y);
        }
    }
}
