using UnityEngine;
using System.Collections;

public class AreaBehaviour : MonoBehaviour {

	GameObject player;
	GameObject enemy;
	Animator anim;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		enemy = this.transform.parent.gameObject;
		anim = enemy.GetComponent<Animator> ();
	}

	void OnTriggerEnter2D (Collider2D PlayerHit) {
		if (PlayerHit == player.GetComponent<Collider2D> ()) {
			enemy.GetComponent<EnemyMovement> ().stop = true;			
			enemy.GetComponent<EnemyMovement> ().chase = new Vector2(player.transform.position.x, enemy.transform.position.y);
			anim.SetBool("Active",true);
		}
	}

	void OnTriggerStay2D (Collider2D PlayerHit) {
		if (PlayerHit == player.GetComponent<Collider2D> ()) {
			enemy.GetComponent<EnemyMovement> ().chase = new Vector2(player.transform.position.x, enemy.transform.position.y);
		}
	}

	void OnTriggerExit2D (Collider2D PlayerLeave) {
		if (PlayerLeave == player.GetComponent<Collider2D> ()) {
			enemy.GetComponent<EnemyMovement> ().stop = false;
			anim.SetBool("Active",false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
