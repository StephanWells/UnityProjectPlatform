using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

	public Animator anim;
	PlayerMovement mov;
	PlayerBehaviour beh;

	public bool working;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		mov = GetComponent<PlayerMovement> ();
		beh = GetComponent<PlayerBehaviour> ();

		working = true;
	}

	void setAllFalse () {
		anim.SetBool ("Walk", false);
		anim.SetBool ("Jump", false);
	}

	void OnCollisionEnter2D (Collision2D coll) {
		if (coll.gameObject.tag == "Crate") {
			anim.SetBool ("Push", true);
		}
	}

	void OnCollisionExit2D (Collision2D coll) {
		if (coll.gameObject.tag == "Crate") {
			anim.SetBool ("Push", false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (working) {
			setAllFalse ();
			if (this.gameObject.GetComponent<Collider2D>().enabled) {
				anim.SetInteger("Dimension",beh.currentDim);
				anim.SetBool ("Jump",!mov.grounded);

				if (mov.grounded) {
					if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.RightArrow)) {
						anim.SetBool ("Walk",true);
					}
				}

				if (anim.GetCurrentAnimatorStateInfo(0).IsName("Buffer")) {
					anim.SetBool ("Ability", false);
				}
			}
		}
	}

	public void reset() {
		setAllFalse ();
		anim.SetBool ("Ability", false);
		anim.SetInteger ("Dimension", 1);
	}
}
