using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour {

    // Use this for initialization
    public GameObject bullet;
    public GameObject ship;
    public AudioSource laserSound;
    float counter = 0.0f;
    float previousCounter = 0.0f;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

            if (Input.GetKeyDown(KeyCode.Space) && (counter-previousCounter >= .8 || previousCounter == 0) )
            {
                Instantiate(bullet, ship.transform.position, ship.transform.rotation); //on spacebar press, makes a bullet at the ships position
                laserSound.Play();
                previousCounter = counter;
            }

        counter += UnityEngine.Time.deltaTime;
    }
    /// <summary>
    /// creates the bullet
    /// </summary>
    /// <summary>
    /// fires the bullet
    /// </summary>
 
}


