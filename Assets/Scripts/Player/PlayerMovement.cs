using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;	
	private float speedDflt;
	private Vector2 startPos;
	public int jumpHeight;
	private int jumpDflt;

	public bool facingLeft;

	private int jumpNum;
	public bool grounded;
	private bool inJump;
	private bool crouch;

	PlayerBehaviour beh;
	Animator anim;

	public LayerMask ground;
	public Transform grounder;
	public float radius;


	// Use this for initialization
	void Start () {
		speedDflt = speed;
		jumpDflt = jumpHeight;
		crouch = false;
		jumpNum = 0;
		inJump = false;
		facingLeft = true;
		startPos = transform.localPosition;

		beh = this.GetComponent<PlayerBehaviour> ();
		anim = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (this.gameObject.GetComponent<Collider2D>().enabled) {
			
			if (Input.GetKey (KeyCode.LeftArrow))
			{
				//GetComponent<Rigidbody2D>().velocity = new Vector2 (-speed, GetComponent<Rigidbody2D>().velocity.y);
				transform.localScale = new Vector3 (0.5F,0.5F,1);
				facingLeft = true;
				GetComponent<Rigidbody2D>().AddForce(new Vector2(-speed, 0), ForceMode2D.Force);
			}
			else if (Input.GetKey (KeyCode.RightArrow))
			{
				//GetComponent<Rigidbody2D>().velocity = new Vector2 (speed, GetComponent<Rigidbody2D>().velocity.y);
				transform.localScale = new Vector3 (-0.5F,0.5F,1);
				facingLeft = false;
				GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, 0), ForceMode2D.Force);
			}
			else
			{
				GetComponent<Rigidbody2D>().velocity = new Vector2 (0, GetComponent<Rigidbody2D>().velocity.y);
			}
		}

		grounded = Physics2D.OverlapCircle (grounder.transform.position, radius, ground);

		/*if (!grounded && jumpNum == 1) {
			grounded = true;
		}*/		
		
		if (grounded && inJump) {
			inJump = false;
			jumpNum = 0;
			anim.SetBool ("Double", false);
		}

		if (beh.currentDim == 3) {
			if (Input.GetKeyDown (KeyCode.UpArrow) && (grounded || inJump) && jumpNum != 2) {
				if (!inJump) {
					inJump = true;
				}

				GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight - jumpNum);
				jumpNum++;
				//rigidbody2D.AddForce (Vector2.up * jumpHeight);
			}

			if (jumpNum == 2 && !anim.GetBool ("Double")) {
				anim.SetBool("Double", true);
			}

			if (grounded && jumpNum == 2) {
				jumpNum = 0;
			}
		} else {
			if (Input.GetKeyDown (KeyCode.UpArrow) && grounded) {						
				GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight - (jumpNum * 2));
				jumpNum++;
			}
			
			if (grounded && jumpNum == 1) {
				jumpNum = 0;
			}
		}

		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			speed = speed / 5;
			crouch = true;
		}
		if (Input.GetKeyUp (KeyCode.DownArrow)) {
			speed = speedDflt;
			crouch = false;
		}

	}

	void OnDrawGizmos() {
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere (grounder.transform.position, radius);
	}

	public void reset() {
		speed = speedDflt;
		jumpHeight = jumpDflt;
		transform.localPosition = startPos;
	}
}
