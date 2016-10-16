using UnityEngine;
using System.Collections;

public class headbob : MonoBehaviour {
    public GameObject player;
    float progress;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W) && player.GetComponent<charControl>().canMove == true){
            progress += Time.deltaTime;
        }
        
        transform.position = new Vector3(transform.position.x, .25f*(Mathf.Sin(progress * player.GetComponent<charControl>().moveSpeed)) -6f, transform.position.z);
	}
}
