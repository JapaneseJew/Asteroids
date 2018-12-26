using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGen : MonoBehaviour {

    // Use this for initialization
    public Camera cam; //camera reference
    public List<GameObject> meteorSpawn = new List<GameObject>();
    private int spawn = 4; //number of meteors to spawn from the start\
    public List<GameObject> spawnedMeteors = new List<GameObject>();
    int rand;
    float totalCamHeight;
    float totalCamWidth;


	void Start () {
        cam = Camera.main;
        totalCamHeight = cam.orthographicSize * 2f;
        totalCamWidth = totalCamHeight * cam.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnedMeteors.Count == 0) //if the list is empty
        {
            SpawnMethod(spawn);
        }
     
    }
    /// <summary>
    /// a method that instantaites each meteor
    /// </summary>
    private void SpawnMethod(int numMeteors)
    {
        for(int i = 0; i < numMeteors; i++)
        {
            rand = Random.Range(0, 4); //random position
            GameObject randPrefab = meteorSpawn[Random.Range(0, meteorSpawn.Count)]; //random prefab
            if(rand == 0 )
            {
                spawnedMeteors.Add(Instantiate(randPrefab, new Vector3(-totalCamWidth, Random.Range(-totalCamHeight, totalCamHeight)), Quaternion.identity)); //instantates at a random place off screen
            }
            else if(rand == 1)
            {
                spawnedMeteors.Add(Instantiate(randPrefab, new Vector3(Random.Range(-totalCamWidth, totalCamWidth), -totalCamHeight), Quaternion.identity)); //instantates at a random place off screen
            }
            else if(rand == 2)
            {
                spawnedMeteors.Add(Instantiate(randPrefab, new Vector3(totalCamWidth, Random.Range(-totalCamHeight, totalCamHeight)), Quaternion.identity)); //instantates at a random place off screen
            }
            else if(rand == 3)
            {
                spawnedMeteors.Add(Instantiate(randPrefab, new Vector3(Random.Range(-totalCamWidth, totalCamWidth), totalCamHeight), Quaternion.identity)); //instantates at a random place off screen
            }
        }
        spawn++;
    }
}
