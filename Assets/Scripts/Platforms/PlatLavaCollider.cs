using UnityEngine;
using System.Collections;

public class PlatLavaCollider : MonoBehaviour {

	PlayerBehaviour beh;

	// Use this for initialization
	void Start () {
		beh = GameObject.Find ("Player").GetComponent<PlayerBehaviour> ();
	}	
	
	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag != "Platform" && coll.gameObject.tag != "Player") {
			Destroy (coll.gameObject, 0.2F);
		}

		if (coll.gameObject.tag == "Player") {
			beh.health = 0;
		}
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
