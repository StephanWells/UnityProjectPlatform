using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour {

	//public EnemyPathfinding pather;

	public Vector2[] nodes;
	public Vector2 chase;
	Animator anim;

	public float speed;

	//private List<Vector2> path;
	[System.NonSerialized]
	public int nextNode;
	[System.NonSerialized]
	public int currentNode;
	//private bool moving;

	[System.NonSerialized]
	public bool pause;
	[System.NonSerialized]
	public bool stop;
	private int pauseCount;
	public int pauseAmount;

	// Use this for initialization
	void Start () {
		transform.position = nodes [0];
		currentNode = 0;
		nextNode = 1;

		//pather = this.GetComponent<EnemyPathfinding> ();

		pause = false;
		stop = false;
		pauseCount = 0;

		anim = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		/*if (!stop) {
			stop = pather.alert;
		}*/

		anim.SetBool ("Pause", pause);

		if (!stop && nodes.Length > 1) {
			if (pause == false) {
				transform.position = Vector2.MoveTowards (transform.position, nodes [nextNode], speed/64);

				if (nodes [currentNode].x > nodes [nextNode].x) {
					transform.localScale = new Vector3 (0.6F,0.6F,0.6F);
				} else {
					transform.localScale = new Vector3 (-0.6F,0.6F,0.6F);
				}

				if ((transform.position.x == nodes [nextNode].x) && (transform.position.y == nodes [nextNode].y)) {
					if (nextNode == nodes.Length - 1) {
						nextNode = 0;
						currentNode++;
					} else if (currentNode == nodes.Length - 1) {
						nextNode++;
						currentNode = 0;
					} else {
						currentNode++;
						nextNode++;
					}
					pause = true;
				}
			} else {
				if (pauseCount < pauseAmount) {
					pauseCount ++;
				} else {
					pauseCount = 0;
					pause = false;
				}
			}
		} else {
			transform.position = Vector2.MoveTowards (transform.position, chase, speed/32);

			if (transform.position.x > chase.x) {
				transform.localScale = new Vector3 (0.6F,0.6F,0.6F);
			} else {
				transform.localScale = new Vector3 (-0.6F,0.6F,0.6F);
			}

		}
	}

	public void reset() {
		transform.position = nodes [0];
		currentNode = 0;
		nextNode = 1;

		stop = false;
		pause = false;
		pauseCount = 0;
	}
}
