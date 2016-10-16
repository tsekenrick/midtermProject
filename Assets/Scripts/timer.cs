using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour {
    public float timer1;
    public float timer2;
    public float timer3;
    public GameObject player;
	// Use this for initialization
	void Start () {
        timer1 = 30f;
        timer2 = 25f;
        timer3 = 20f;
	}
	
	// Update is called once per frame
	void Update () {
        if (player.GetComponent<charControl>().canMove == true)
        {
            timer1 -= Time.deltaTime;
        }

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
