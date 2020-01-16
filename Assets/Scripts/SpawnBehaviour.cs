using UnityEngine;
using System.Collections;

public class SpawnBehaviour : MonoBehaviour {

	public Rigidbody2D toSpawn;
	public float spawnTime;
	public float waitBeforeStart;
	private float timer;

	// Use this for initialization
	void Start () {
		waitBeforeStart = waitBeforeStart + Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody2D instance;

		if (Time.time > waitBeforeStart) {
			if (timer <= Time.time) {
				instance = Instantiate(toSpawn, new Vector2(transform.position.x, transform.position.y - 0.1F), transform.rotation) as Rigidbody2D;
				
				timer = Time.time + spawnTime;
			}
		}	
	}
}
