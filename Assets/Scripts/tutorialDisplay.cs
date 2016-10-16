using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class tutorialDisplay : MonoBehaviour {
    public Text tutorial;
    public float displayTime;
    public GameObject player;
    public AudioSource crowd;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        displayTime += Time.deltaTime;

        if (displayTime > 8f)
        {
            tutorial.text = "";
            player.GetComponent<charControl>().canMove = true;
            //crowd.Play();
        }
        else if (displayTime < 3.25f)
        {
            tutorial.text = "You're training for a sprint! Press [Shift] to run. Finish a lap before the timer runs out!";
        }
        else if (displayTime < 6.5f)
        {
            tutorial.text = "Don't run out of stamina, or you'll become fatigued. Avoid fatigue for a lap, and your stamina improves!";
        }
        else if (displayTime < 8f)
        {
            tutorial.text = "Go get 'em! The home crowd is cheering!";
        }
	
	}
}
