using UnityEngine;
using System.Collections;

public class PlatExitCollider : MonoBehaviour {

	PlayerBehaviour beh;

	// Use this for initialization
	void Start () {
		beh = GameObject.Find ("Player").GetComponent<PlayerBehaviour> ();
	}
	
	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "Player") {
			beh.win = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
