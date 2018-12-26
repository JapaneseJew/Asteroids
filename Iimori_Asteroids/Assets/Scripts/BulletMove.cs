using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public Camera cam;
    public GameObject bullet;
    private Vector3 bulletPosition; //default position
    Vector3 bulletDirection = new Vector3(1, 0, 0);
    public Vector3 velocity = new Vector3(0, 0, 0);
    public float speed;
    GameObject move;
    private float totalCamHeight;
    private float totalCamWidth;


    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
        totalCamHeight = cam.orthographicSize * 2f;//these two lines find the height and width of the camera
        totalCamWidth = totalCamHeight * cam.aspect;

        move = GameObject.Find("Ship"); //find the ship
        bulletDirection = move.GetComponent<Movement>().direction;
        //direction * speed = velocity
        velocity = bulletDirection * speed;
    }

    // Update is called once per frame
    void Update()
    {
        bulletPosition = transform.position;
        //add velocity to position
        bulletPosition += velocity;
        //draw at position
        bullet.transform.position = bulletPosition;

        if(bullet.transform.position.y > totalCamHeight  || bullet.transform.position.y < -totalCamHeight)
        {
            Destroy(bullet);
        }
        if(bullet.transform.position.x > totalCamWidth || bullet.transform.position.x < -totalCamWidth)
        {
            Destroy(bullet);
        }
    }
}
