using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class finishLine : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter (Collider collision)
    {
        int currentStage = SceneManager.GetActiveScene().buildIndex;
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(currentStage + 1);
        }
    }
}
