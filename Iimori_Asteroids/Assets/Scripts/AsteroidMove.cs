using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMove : MonoBehaviour {
    Vector3 astPosition;
    public Vector3 astDirection;
    Vector3 astVelocity = new Vector3();
    public float speed;
    GameObject temp;
	// Use this for initialization
	void Start () {
        astDirection = new Vector3(Random.Range(-11, 11), Random.Range(-11,11), 0);
        //astPosition = transform.position; //sets position to wherever it spawns
        //temp = GameObject.Find("Ship");
        //astDirection = temp.transform.position-this.transform.position;
        astDirection = Vector3.Normalize(astDirection); //normalize the direction vector
       // astVelocity = astDirection * speed;
	}

	
	// Update is called once per frame
	void Update () {
        astPosition = transform.position;
        //makes the velocity scale by the speed
        astVelocity = astDirection* speed;
        Debug.Log(astVelocity);
        //adds the velocity to the position every frame
        astPosition += astVelocity;
        //transforms the position
        transform.position = astPosition;
        
    }

 

}
