using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour {
    public float timer1;
    public float timer2;
    public float timer3;
	// Use this for initialization
	void Start () {
        timer1 = 60f;
        timer2 = 50f;
        timer3 = 40f;
	}
	
	// Update is called once per frame
	void Update () {
        timer1 -= Time.deltaTime;
        timer2 -= Time.deltaTime;
        timer3 -= Time.deltaTime;

        if (SceneManager.GetActiveScene().buildIndex == 0 && timer1 <= 0)
        {
            SceneManager.LoadScene(4);
        }

        if (SceneManager.GetActiveScene().buildIndex == 1 && timer2 <= 0)
        {
            SceneManager.LoadScene(4);
        }

        if (SceneManager.GetActiveScene().buildIndex == 2 && timer3 <= 0)
        {
            SceneManager.LoadScene(4);
        }
    }
}
