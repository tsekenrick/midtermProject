using UnityEngine;
using System.Collections;

public class randMaterial : MonoBehaviour {
    Renderer rend;
	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        rend.material.color = Random.ColorHSV();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
