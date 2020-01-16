using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	GameObject player;
	Animator anim;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		anim = this.GetComponent<Animator> ();

	}

	void OnCollisionEnter2D (Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
			player.GetComponent<Rigidbody2D>().AddForce(new Vector2(3000.0F,100.0F));
			anim.SetBool ("Attack", true);
		}
	}

	void OnCollisionExit2D (Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
			anim.SetBool ("Attack", false);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
