using UnityEngine;
using System.Collections;

public class EnemyMovement2 : MonoBehaviour {

	GameObject player;
	PlayerBehaviour beh;

	public float speed;
	public bool active;
	private Vector2 origin;
	private float posX;
	private float posY;
	private Vector2 moveTo;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		beh = player.GetComponent<PlayerBehaviour> ();
		active = false;
		origin = this.transform.position;
		moveTo = this.transform.position;
	}

	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "Player") {
			beh.lose = true;
		}
	}

	// Update is called once per frame
	void Update () {
		if (active) {
			transform.position = Vector2.MoveTowards (transform.position, player.transform.position, speed/200);
		} else {
			if ((transform.position.x == moveTo.x) && (transform.position.y == moveTo.y)) {
				posX = Random.Range (origin.x - 1.5F, origin.x + 1.5F);
				posY = Random.Range (origin.y - 1.5F, origin.y + 1.5F);

				 moveTo = new Vector2(posX,posY);
			}

			transform.position = Vector2.MoveTowards (transform.position, moveTo, speed/200);
		}
	}
}
