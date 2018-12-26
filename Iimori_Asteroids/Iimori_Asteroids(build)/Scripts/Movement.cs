using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    //public float speed;

    //necessary
    public float rateOfAccel;
    public float rateOfDeAccel;
    public float lowBound;
    public float maxSpeed;                                    //limit magnitude of velocity
    public float rotationSpeed;
    public float angleOfRotation;                           //0
    public Vector3 vehiclePosition = new Vector3(0, 0, 0); //or Vector3.zero
    public Vector3 direction = new Vector3(1, 0, 0); //right, 0 degrees
    public Vector3 velocity = new Vector3(0, 0, 0);
    public Vector3 acceleration = new Vector3(0, 0, 0);

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        vehiclePosition = transform.position;
        //separate into methods
        acceleration = new Vector3();
        RotateVehicle();

        Drive();

        SetTransform();




    }
    /// <summary>
    /// 
    /// </summary>
    public void RotateVehicle()
    {
        //rotate the vehicle by 1 degree
        //direction = Quaternion.Euler(0, 0, 1) * direction;
        //left arrow = 1 degree to left
        //right arrow = 1 degree to right
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = Quaternion.Euler(0, 0, rotationSpeed) * direction;
            angleOfRotation += rotationSpeed;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = Quaternion.Euler(0, 0, -rotationSpeed) * direction;
            angleOfRotation -= rotationSpeed;
        }

    }
    /// <summary>
    /// 
    /// </summary>
    public void Drive()
    {
        //Increase speed for acceleration
        //speed += rateOfAccel;



        //add acceleration to velocity
        if (Input.GetKey(KeyCode.UpArrow))
        {
            acceleration += rateOfAccel * direction;
            /*velocity += acceleration;

            //move vehicle along velocity
            //velocity = speed * direction;

            //limit vel vector with ClampMagnitude
            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

            //add vel to positoin
            vehiclePosition += velocity;*/
        }
        if (velocity.x != 0 || velocity.y != 0 || velocity.z != 0)
        {
            acceleration += rateOfDeAccel * -velocity;
            //Debug.Log(acceleration);

        }
        if (velocity.x < lowBound && velocity.x > -lowBound)
        {
            velocity.x = 0;
        }
        if (velocity.y < lowBound && velocity.y > -lowBound)
        {
            velocity.y = 0;
        }
        velocity += acceleration;

        //move vehicle along velocity
        //velocity = speed * direction;

        //limit vel vector with ClampMagnitude
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        //add vel to positoin
        vehiclePosition += velocity;


    }
    /// <summary>
    /// 
    /// </summary>
    public void SetTransform()
    {
        //rotate the vehicle to face the correct direction
        transform.rotation = Quaternion.Euler(0, 0, angleOfRotation);
        //position vehicle ("draw it")
        transform.position = vehiclePosition;
    }


}

