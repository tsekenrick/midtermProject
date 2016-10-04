using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {
    //"static" is a keyword to make the variable live in the code and not in the scene - it will NOT reset on scene change.
    public static int sceneChosen;
    //if you want data to persist even if you quit game, use PlayerPrefs
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            sceneChosen = 1;
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            sceneChosen = 2;
        }
	}
}
