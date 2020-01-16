using UnityEngine;
using System.Collections;

public class AbilAirCollider : MonoBehaviour {

	public int direction;

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D (Collider2D coll) {		
		if (coll.gameObject.tag == "Crate") {
			Destroy (this.gameObject);
			coll.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(50000.0F * direction,50000.0F));
			coll.gameObject.GetComponent<Rigidbody2D>().AddTorque (2000.0F * direction);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
