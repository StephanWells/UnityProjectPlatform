using UnityEngine;
using System.Collections;

public class PlatSpikeCollider : MonoBehaviour {

	PlayerBehaviour beh;
	private bool alreadyHit;

	// Use this for initialization
	void Start () {
		beh = GameObject.Find ("Player").GetComponent<PlayerBehaviour> ();
		alreadyHit = false;
	}

	void OnCollisionEnter2D (Collision2D coll) {
		if (coll.gameObject.tag == "Platform" || coll.gameObject.tag == "Crate") {
			Destroy (this.gameObject, 0.1F);
		}

		if (coll.gameObject.tag == "Player" && !alreadyHit) {
			beh.health -= 25;
			alreadyHit = true;
			Destroy (this.gameObject, 0.1F);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
