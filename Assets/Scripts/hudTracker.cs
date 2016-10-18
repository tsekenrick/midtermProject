using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class hudTracker : MonoBehaviour {
    public Text stats;
    public GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        stats.text = "Stamina: " + string.Format("{0:0.00}", player.GetComponent<charControl>().stamina);

	}
}
