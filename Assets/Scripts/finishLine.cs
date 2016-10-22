using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class finishLine : MonoBehaviour {
    int currentStage;
    Scene scene;
    public float timeElapsed;
    // Use this for initialization
    void Start () {
        int currentStage = SceneManager.GetActiveScene().buildIndex;
    }
	
	// Update is called once per frame
	void Update () {

        timeElapsed += Time.deltaTime;
        //scene = SceneManager.GetActiveScene();
        if (Input.GetKey(KeyCode.T))
        {
            //PlayerPrefs.SetInt("wasFatigueds1", 0);
            //PlayerPrefs.SetInt("wasFatigueds1", 0);
            //SceneManager.LoadScene(scene.name);
            SceneManager.LoadScene(0);
        }
    }

    void OnTriggerEnter (Collider collision)
    {
        int currentStage = SceneManager.GetActiveScene().buildIndex;
        if (collision.gameObject.tag == "Player" && timeElapsed > 15f)
        {
            SceneManager.LoadScene(currentStage + 1);
        }
    }
}
