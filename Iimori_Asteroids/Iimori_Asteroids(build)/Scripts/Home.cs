using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour {

	// Use this for initialization
    /// <summary>
    /// used to go to home
    /// </summary>
	void Start () {
        SceneManager.LoadScene("asteroids"); //load asteroids
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
