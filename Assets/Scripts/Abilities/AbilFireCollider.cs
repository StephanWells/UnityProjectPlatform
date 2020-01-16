using UnityEngine;
using System.Collections;

public class AbilFireCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter2D (Collision2D coll) {		
		if (coll.gameObject.tag == "Enemy") {
			Destroy (this.gameObject);
			Destroy (coll.gameObject);
		} else {
			Destroy (this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
