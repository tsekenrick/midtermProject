using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fatigueDisplay : MonoBehaviour {
    public Text fatigueDisp;
    public GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if (player.GetComponent<charControl>().fatigued == true)
        {
            fatigueDisp.text = "You're fatigued! Recovery in " + string.Format("{0:0.00}", player.GetComponent<charControl>().recoveryRate) + " seconds";
        }
        else
        {
            fatigueDisp.text = "";
        }
	}
}
