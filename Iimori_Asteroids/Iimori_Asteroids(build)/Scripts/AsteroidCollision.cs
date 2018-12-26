using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour {

    // Use this for initialization
    //BulletCollision retrieverObject;
    AsteroidGen listRetriever;
    List<GameObject> meteorSpawned;
    public int health;
    public GameObject sGObject1;
    public GameObject sGObject2;
    public GameObject sGObject3;
    public GameObject sGObject4;
    GameObject scoreObject;
    UI scoreKeep;

    void Start () {
        listRetriever = GameObject.Find("SceneManager").GetComponent<AsteroidGen>(); //gets the asteroidgen script from the scenemanager
        meteorSpawned = listRetriever.spawnedMeteors; //the meteors spawned are stored in this list
        scoreObject = GameObject.Find("SceneManager"); //finds the scenemanager
        scoreKeep = scoreObject.GetComponent<UI>(); //makes a UI object and sets it equal to the scoreObject, which is grabbing the UI script

    }
	
	// Update is called once per frame
	void Update () {

        scoreKeep = scoreObject.GetComponent<UI>(); //makes a UI object and sets it equal to the scoreObject, which is grabbing the UI script

    }
    /// <summary>
    /// A method called on bulletcollision to instruct the meteor to die 
    /// </summary>
    public void Hit()
    {
        if (health == 2) //as long as it collides and the health is 2 (the big meteors)
        {
            // Add 20 to points

            for (int i = 0; i < 2; i++) //generate two meteors
            {
                int randSmaller = Random.Range(0, 4); //based on the random number, generates a different meteor and adds it to the list of meteors
                if (randSmaller == 0)
                {
                    GameObject miniMeteor = Instantiate(sGObject1, this.transform.position, this.transform.rotation); //new meteor object for smaller meteor 
                    // small guy's direction = Quaternion.Euler(0, 0, Random value) * big guy's direction;
                    miniMeteor.GetComponent<AsteroidMove>().astDirection = Quaternion.Euler(0, 0, Random.Range(1f, 10f)) * gameObject.GetComponent <AsteroidMove>().astDirection; //takes the new small meteor 
                    //and makes its direction equal to the old meteors direction rotated by up to 10 degrees
                    meteorSpawned.Add(miniMeteor); //adds it to the "spawned" list. The repeated code of this for loop is the same.
                }
                if (randSmaller == 1)
                {
                    GameObject miniMeteor2 = Instantiate(sGObject2, this.transform.position, this.transform.rotation);
                    miniMeteor2.GetComponent<AsteroidMove>().astDirection = Quaternion.Euler(0, 0, Random.Range(1f, 10f)) * gameObject.GetComponent<AsteroidMove>().astDirection;
                    meteorSpawned.Add(miniMeteor2);
                    //meteorSpawned.Add(Instantiate(sGObject2, this.transform.position, this.transform.rotation));
                }
                if (randSmaller == 2)
                {
                    GameObject miniMeteor3 = Instantiate(sGObject3, this.transform.position, this.transform.rotation);
                    miniMeteor3.GetComponent<AsteroidMove>().astDirection = Quaternion.Euler(0, 0, Random.Range(1f, 10f)) * gameObject.GetComponent<AsteroidMove>().astDirection;
                    meteorSpawned.Add(miniMeteor3);
                    //meteorSpawned.Add(Instantiate(sGObject3, this.transform.position, this.transform.rotation));
                }
                if (randSmaller == 3)
                {
                    GameObject miniMeteor4 = Instantiate(sGObject4, this.transform.position, this.transform.rotation);
                    miniMeteor4.GetComponent<AsteroidMove>().astDirection = Quaternion.Euler(0, 0, Random.Range(1f, 10f))  * gameObject.GetComponent<AsteroidMove>().astDirection;
                    meteorSpawned.Add(miniMeteor4);
                    //meteorSpawned.Add(Instantiate(sGObject4, this.transform.position, this.transform.rotation));
                }
                //Debug.Log("I have created life, sue me at " + randSmaller);
            }
            scoreKeep.score += 20; //increments the score from "scorekeep," IE UI
 
            Destroy(this.gameObject); //then destroys the meteor 
        }
        if (health == 1) //if its one of the smaller meteors, just destroy it
        {
            scoreKeep.score += 50; //increments the score from "scorekeep," IE UI
            Destroy(this.gameObject);
        }
    }

}
