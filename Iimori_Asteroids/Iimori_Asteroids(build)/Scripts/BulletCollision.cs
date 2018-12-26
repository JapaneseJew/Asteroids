using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour {

    // Use this for initialization
    // Use this for initialization
    public GameObject gObject;
    public List<GameObject> asteroids;
    AudioSource explosion;
    AsteroidGen retrieverObject;
    void Start()
    {
        retrieverObject = GameObject.Find("SceneManager").GetComponent<AsteroidGen>(); //get the asteroidGen script from scenemanager
        explosion = GameObject.Find("Ship").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        asteroids = retrieverObject.spawnedMeteors; //get the meteorSpawn list
        //Debug.Log(asteroids.Count);
        if (BoundingCircle() == true)
        {
            explosion.Play(); //play explosion
            Destroy(this.gameObject);
        }
    }


    /// <summary>
    /// a method that checks bounding circles of objects
    /// </summary>
    /// <returns></returns>
    private bool BoundingCircle()
    {
        for (int i = 0; i < asteroids.Count; i++)
        {
            Vector2 distance = gObject.transform.position - asteroids[i].transform.position;
            float distanceBetween = distance.magnitude;
            if (gObject.GetComponent<CircleCollider2D>().radius + asteroids[i].GetComponent<CircleCollider2D>().radius > distanceBetween)
            {
                //asteroids[i].GetComponent<SpriteRenderer>().color = Color.red;
                asteroids[i].GetComponent<AsteroidCollision>().Hit();
                asteroids.Remove(asteroids[i]);
                return true;
            }
            asteroids[i].GetComponent<SpriteRenderer>().color = Color.white;
        }
        return false;
    }
}
