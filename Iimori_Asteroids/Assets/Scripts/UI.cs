using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {

    // Single point value that all asteroids/ship/bullets/whatever reference
    public int score = 0;
    private List<GameObject> life = new List<GameObject>();
    public GameObject heart;
    Collision tempStorage;
    int shipLife;
	// Use this for initialization
	void Start () {
        life.Add(Instantiate(heart, new Vector3(-4.5f, 4.55f, 0), Quaternion.identity)); ///instantiate three hearts
        life.Add(Instantiate(heart, new Vector3(-3.5f, 4.55f, 0), Quaternion.identity));
        life.Add(Instantiate(heart, new Vector3(-2.5f, 4.55f, 0), Quaternion.identity));
	}
	
	// Update is called once per frame
	void Update () {
        //GameObject.Find("");
        tempStorage = GameObject.Find("CollisionManager").GetComponent<Collision>(); //finds the collision script on the collisionmanager and stores it in a temp
        shipLife = tempStorage.life; //gets the life value of this temp
        if(shipLife == 2) //if the life is equal to 2, destroy the second life in the index
        {
            Destroy(life[2]);
        }
        if (shipLife == 1) //same for one
        {
            Destroy(life[1]);
        }
        if (shipLife == 0)
        {
            Destroy(life[0]);
        }
       

	}
    /// <summary>
    /// draw score to screen
    /// </summary>
    void OnGUI()
    {
        GUI.color = Color.white; //change the color
        GUI.skin.box.fontSize = 20; //increase text size
        GUI.Box(new Rect(0f, 9f, 200, 30), "score: " + score);
    }
}
