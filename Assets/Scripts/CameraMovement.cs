using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	
	Transform target;
	
	// Use this for initialization
	void Start () {
		target = GameObject.Find ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = target.position + new Vector3 (0, 0, -10);
		
		/*if ((transform.position.x + Camera.main.pixelWidth) == levelWidth) {
			transform.position.Set(levelWidth - Camera.main.pixelWidth, transform.position.y, transform.position.z);
		}*/
	}
}