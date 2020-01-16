using UnityEngine;
using System.Collections;

public class AreaBehaviour2 : MonoBehaviour {

	GameObject player;
	public GameObject enemy;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}

	void OnTriggerEnter2D (Collider2D PlayerHit) {
		if (PlayerHit == player.GetComponent<Collider2D> ()) {
			enemy.GetComponent<EnemyMovement2> ().active = true;
		}
	}

	void OnTriggerExit2D (Collider2D PlayerLeave) {
		if (PlayerLeave == player.GetComponent<Collider2D> ()) {
			enemy.GetComponent<EnemyMovement2> ().active = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
