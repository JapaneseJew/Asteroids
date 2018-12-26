using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// script for collision between plane and asteroids
/// </summary>
public class Collision : MonoBehaviour
{

    // Use this for initialization
    // Use this for initialization
    public GameObject gObject;
    public List<GameObject> asteroids;
    AsteroidGen retrieverObject;
    //public bool collided = false;
    public int life;
    bool invincible = false;
    float currentTime = 0.0f;
    float prevTime = 0.0f;
    void Start()
    {
        retrieverObject = GameObject.Find("SceneManager").GetComponent<AsteroidGen>(); //get the asteroidGen script from scenemanager
        asteroids = retrieverObject.spawnedMeteors; //get the meteorSpawn list
    }

    // Update is called once per frame
    void Update()
    {
        if (invincible == true) //if you are invincible 
        {
            Switch(); //calls switch, switching between invicibility = true and false after .8 s
        }
        if (BoundingCircle() == true && life != 0 && invincible == false)
        {
            life--;
            invincible = true;
           
        }
        if (life == 0)
        {
            SceneManager.LoadScene("Game Over", LoadSceneMode.Single); //loads the game over scene after death;

        }


    }


    /// <summary>
    /// a method that checks bounding circles of objects for collisions
    /// </summary>
    /// <returns></returns>
    private bool BoundingCircle()
    {
        for (int i = 0; i < asteroids.Count; i++)
        {
            Vector3 distance = gObject.transform.position - asteroids[i].transform.position;                   
            float distanceBetween = distance.magnitude;
            //Vector3 endPosition = gObject.transform.position + (new Vector3(1, 1, 0) * gObject.GetComponent<CircleCollider2D>().radius);
            //Debug.DrawLine(gObject.transform.position, endPosition);
            //Debug.DrawLine(listElement.transform.position,listElement.transform.position + (new Vector3(1,1,0) * listElement.GetComponent<CircleCollider2D>().radius));
            if (gObject.GetComponent<CircleCollider2D>().radius + asteroids[i].GetComponent<CircleCollider2D>().radius > distanceBetween)
            {
                gObject.GetComponent<SpriteRenderer>().color = Color.red; //turns ship red if you collide with something
                //Debug.Log(listElement);
                //collided = true;
                return true;
            }
            gObject.GetComponent<SpriteRenderer>().color = Color.white; //makes ship normal color if you aren't colliding
        }
        //collided = false;
        return false;
    }

    /// <summary>
    /// method for giving invincibility time
    /// </summary>
    private void Switch()
    {
        currentTime += UnityEngine.Time.deltaTime; //updates the current time using delta time
        if (currentTime - prevTime >= 1 ) //if it's been 1 second since last time the time was checked, do this 
        {
            invincible = false; //invincible is false
            prevTime = currentTime; //prevTime = currentTime
            return; //end 
        }
        

    }



}

