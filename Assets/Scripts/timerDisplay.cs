using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timerDisplay : MonoBehaviour {
    public Text timerDisp;
    public GameObject timer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            timerDisp.text = "Day 1 of training. \nTime left for track: " + string.Format("{0:0.00}",timer.GetComponent<timer>().timer1);
        }

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            timerDisp.text = "Day 2 of training. \nTime left for track: " + timer.GetComponent<timer>().timer2.ToString();
        }

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            timerDisp.text = "Today's the day! Good luck! \nTime left for track: " + timer.GetComponent<timer>().timer3.ToString();
        }

    }
}
