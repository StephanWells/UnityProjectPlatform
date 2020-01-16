using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

	public bool win;
	public bool lose;
	public int health;
	public int mana;
	public int level;

	public int currentDim = 1;

	public float cdShockwave = 5.0F;
	public float timerShockwave;

	public float cdInvun = 30.0F;
	public float timerInvun;
	private const float invunLength = 2.0F;
	private float invun;
	private Vector2 freezePos;

	public float cdFireball = 10.0F;
	public float timerFireball;

	public float cdTornado = 10.0F;
	public float timerTornado;

	private Vector3 direction;
	private int director;
	private Vector2 spawn;
	public Rigidbody2D shockwave;
	public Rigidbody2D fireball;
	public Rigidbody2D tornado;

	GameObject fire;
	GameObject pulse;
	GameObject air;
	GameObject disp;
	
	private GameObject[] backgrounds;

	PlayerMovement mov;
	Animator anim;
	PlayerAnimation animP;

	// Use this for initialization
	void Start () {
		win = false;
		lose = false;
		health = 50;
		mana = 50;

		fire = GameObject.Find ("Sear");
		pulse = GameObject.Find ("Pulse");
		air = GameObject.Find ("Cyclone");
		disp = GameObject.Find ("Disperse");
		
		backgrounds = new GameObject[4];

		mov = this.GetComponent<PlayerMovement> ();
		anim = this.GetComponent<Animator> ();
		animP = this.GetComponent<PlayerAnimation> ();
		
		backgrounds[0] = GameObject.Find ("GRID Red");
		backgrounds[0].SetActive (true);
		backgrounds[1] = GameObject.Find ("GRID Blue");
		backgrounds[1].SetActive (false);
		backgrounds[2] = GameObject.Find ("GRID Green");
		backgrounds[2].SetActive (false);
		backgrounds[3] = GameObject.Find ("GRID Purple");
		backgrounds[3].SetActive (false);

		currentDim = 1;

		timerShockwave = 0;
		timerInvun = 0;
		timerFireball = 0;
	}
	
	void DrawOutline(Rect r, string t, int strength, GUIStyle style)
	{
		GUI.color = new Color(0, 0, 0, 1);
		
		int i;
		
		for (i = -strength; i <= strength; i++)
		{
			GUI.Label(new Rect(r.x - strength, r.y + i, r.width, r.height), t, style);
			GUI.Label(new Rect(r.x + strength, r.y + i, r.width, r.height), t, style);
		}
		
		GUI.color = new Color(1, 1, 1, 1);
		
		for (i = -strength + 1; i <= strength - 1; i++){
			GUI.Label(new Rect(r.x + i, r.y - strength, r.width, r.height), t, style);
			GUI.Label(new Rect(r.x + i, r.y + strength, r.width, r.height), t, style);
		}
	}
	
	void OnGUI()
	{
		
		if (win)
		{
			GUI.Window(0, new Rect((Screen.width / 2) - 150, (Screen.height / 2) - 100, 300, 250), ShowGUI, "SUCCESS");
		}
		
		if (lose)
		{
			GUI.Window(1, new Rect((Screen.width / 2) - 150, (Screen.height / 2) - 100, 300, 250), ShowGUI, "FAILURE");
		}
	}
	
	void ShowGUI(int windowID)
	{
		var centeredStyle = GUI.skin.GetStyle("Button");
		centeredStyle.alignment = TextAnchor.MiddleCenter;
		
		var centeredStyle2 = GUI.skin.GetStyle("Label");
		centeredStyle2.alignment = TextAnchor.UpperCenter;
		
		switch (windowID)
		{
			case 0:
				GUI.Label(new Rect(52, 40, 200, 30), "Level Complete!", centeredStyle2);
				break;				
			case 1:
				GUI.Label(new Rect(52, 40, 200, 30), "Retry?", centeredStyle2);
				break;
		}
		
		if (GUI.Button(new Rect(115, 180, 75, 30), "OK", centeredStyle))
		{
			if (lose) {
				Application.LoadLevel(Application.loadedLevel);
			} else if (win) {
				if (level == 5) {
					Application.LoadLevel ("Menu");
				} else {
					level++;
					Application.LoadLevel("Level" + level);
				}
			}

			win = false;
			lose = false;
			health = 50;

			timerInvun = Time.time;
			timerFireball = Time.time;
			timerShockwave = Time.time;
		}
		
	}
	
	// Update is called once per frame
	void Update () {		
		if (health < 0) {
			health = 0;
		}

		if (health == 0) {
			lose = true;
			anim.SetBool("Dead", true);
		}

		if (lose || win) {
			mov.speed = 0;
			mov.jumpHeight = 0;
			animP.working = false;
			//anim.working = false;
		}

		if (invun <= Time.time && !this.gameObject.GetComponent<Collider2D>().enabled) {
			this.gameObject.GetComponent<Collider2D>().enabled = true;
			this.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
			anim.SetBool ("Invun", false);
		}

		if (mov.facingLeft) {
			spawn = new Vector2 (transform.position.x - 0.25F, transform.position.y);
			direction = new Vector3(1F,1F,1F);
			director = -1;
		} else {
			spawn = new Vector2 (transform.position.x + 0.25F, transform.position.y);
			direction = new Vector3(-1F,1F,1F);
			director = 1;
		}

		if (Input.GetKeyDown (KeyCode.A)) {
			currentDim = 1;
			
			backgrounds[0].SetActive (true);
			backgrounds[1].SetActive (false);
			backgrounds[2].SetActive (false);
			backgrounds[3].SetActive (false);
		}
		
		if (Input.GetKeyDown (KeyCode.W)) {
			currentDim = 2;
			
			backgrounds[0].SetActive (false);
			backgrounds[1].SetActive (true);
			backgrounds[2].SetActive (false);
			backgrounds[3].SetActive (false);
		}
		
		if (Input.GetKeyDown (KeyCode.E)) {
			currentDim = 3;
			
			backgrounds[0].SetActive (false);
			backgrounds[1].SetActive (false);
			backgrounds[2].SetActive (true);
			backgrounds[3].SetActive (false);
		}
		
		if (Input.GetKeyDown (KeyCode.R)) {
			currentDim = 4;
			
			backgrounds[0].SetActive (false);
			backgrounds[1].SetActive (false);
			backgrounds[2].SetActive (false);
			backgrounds[3].SetActive (true);
		}

		//Rigidbody2D instance;

		if (Input.GetKeyDown (KeyCode.F)) {
			switch (currentDim) {
				case 1:
					if (timerFireball <= Time.time) {
						anim.SetBool ("Ability", true);
						Invoke ("launchFireball",0.4F);
						fire.GetComponent<AudioSource> ().Play ();
						timerFireball = Time.time + cdFireball;
						
						
					}
					break;
				case 2:
					if (timerShockwave <= Time.time) {
						anim.SetBool ("Ability", true);						
						Invoke ("launchShockwave",0.3F);
						pulse.GetComponent<AudioSource> ().Play ();
						timerShockwave = Time.time + cdShockwave;
					}
					break;
				case 3:
					if (timerTornado <= Time.time) {
						anim.SetBool ("Ability", true);
						Invoke ("launchTornado",0.9F);
						air.GetComponent<AudioSource> ().Play ();
						timerTornado = Time.time + cdTornado;
					}
					break;
				case 4:
					if (timerInvun <= Time.time) {
						disp.GetComponent<AudioSource> ().Play ();
						anim.SetBool ("Ability", true);
						anim.SetBool ("Invun", true);
						timerInvun = Time.time + cdInvun;
						invun = Time.time + invunLength;
						this.gameObject.GetComponent<Collider2D>().enabled = false;
						this.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
					}
					break;
			}
		}
	}

	void launchFireball() {
		Rigidbody2D instance;
		instance = Instantiate(fireball, spawn, transform.rotation) as Rigidbody2D;
		instance.gameObject.transform.localScale = Vector3.Scale (instance.gameObject.transform.localScale, direction);
		instance.velocity = transform.TransformDirection (Vector2.right * 5 * director);
		Destroy(instance.gameObject, 1.0F);
	}

	void launchTornado() {
		Rigidbody2D instance;
		instance = Instantiate(tornado, spawn, transform.rotation) as Rigidbody2D;
		instance.gameObject.transform.localScale = Vector3.Scale (instance.gameObject.transform.localScale, direction);
		instance.velocity = transform.TransformDirection (Vector2.right * 5 * director);
		instance.GetComponent<AbilAirCollider> ().direction = director;
		Destroy(instance.gameObject, 2.0F);
	}


	void launchShockwave() {
		Rigidbody2D instance1;
		instance1 = Instantiate(shockwave, new Vector2 (transform.position.x + 0.25F, transform.position.y), transform.rotation) as Rigidbody2D;
		instance1.gameObject.transform.localScale = Vector3.Scale (instance1.gameObject.transform.localScale, new Vector3(-1F,1F,1F));
		instance1.velocity = transform.TransformDirection (Vector2.right * 5);
		Destroy(instance1.gameObject, 0.2F);

		Rigidbody2D instance2;
		instance2 = Instantiate(shockwave, new Vector2 (transform.position.x - 0.25F, transform.position.y), transform.rotation) as Rigidbody2D;
		instance2.gameObject.transform.localScale = Vector3.Scale (instance2.gameObject.transform.localScale, new Vector3(1F,1F,1F));
		instance2.velocity = transform.TransformDirection (Vector2.right * -5);
		Destroy(instance2.gameObject, 0.2F);
	}
}
