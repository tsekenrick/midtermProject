using UnityEngine;
using System.Collections;

public class textTriggers : MonoBehaviour {
    public string[] goodbyeStrings;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

	}

    void OnTriggerEnter (Collider collision)
    {
        collision.transform.localScale *= 1.1f;
    }

    void OnTriggerExit()
    {
        Debug.Log(goodbyeStrings[Random.Range(0, goodbyeStrings.Length)]);
    }
}
