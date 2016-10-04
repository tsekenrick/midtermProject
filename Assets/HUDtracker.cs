﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDtracker : MonoBehaviour {
    public Text stats;
    public GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        stats.text = "Stamina: " + player.GetComponent<charControl>().stamina.ToString() + "\nRecovery: " + player.GetComponent<charControl>().recoveryRate.ToString();
	}
}
