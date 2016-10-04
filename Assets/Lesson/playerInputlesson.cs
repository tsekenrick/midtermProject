using UnityEngine;
using System.Collections;

public class playerInputlesson : MonoBehaviour {
     CharacterController charControl;
	// Use this for initialization
	void Start () {
        charControl = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        charControl.SimpleMove(transform.forward * Input.GetAxis("Vertical") * 500f * Time.deltaTime + transform.right * Input.GetAxis("Horizontal") * 500f * Time.deltaTime);
	}
}
