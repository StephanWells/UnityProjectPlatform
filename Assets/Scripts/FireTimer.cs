using UnityEngine;
using System.Collections;

public class FireTimer : MonoBehaviour {

	PlayerBehaviour beh;
	GameObject redBG;
	GameObject blueBG;
	GameObject greenBG;
	GameObject purpleBG;
	Vector2 posR, posB, posG, posP;

	// Use this for initialization
	void Start () {
		beh = GameObject.Find ("Player").GetComponent<PlayerBehaviour> ();
		redBG = GameObject.Find ("fireUnderlay");
		blueBG = GameObject.Find ("shockUnderlay");
		greenBG = GameObject.Find ("windUnderlay");
		purpleBG = GameObject.Find ("cloudUnderlay");
		posR = GetComponent<Camera>().WorldToScreenPoint (redBG.transform.position);
		posB = GetComponent<Camera>().WorldToScreenPoint (blueBG.transform.position);
		posG = GetComponent<Camera>().WorldToScreenPoint (greenBG.transform.position);
		posP = GetComponent<Camera>().WorldToScreenPoint (purpleBG.transform.position);
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

	void OnGUI() {		
		GUIStyle fireFont = new GUIStyle();
		fireFont.fontSize = 40;
		fireFont.alignment = TextAnchor.MiddleCenter;
		fireFont.normal.textColor = Color.red;
		
		GUIStyle shockwaveFont = new GUIStyle();
		shockwaveFont.fontSize = 40;
		shockwaveFont.alignment = TextAnchor.MiddleCenter;
		shockwaveFont.normal.textColor = Color.blue;
		
		GUIStyle windFont = new GUIStyle();
		windFont.fontSize = 40;
		windFont.alignment = TextAnchor.MiddleCenter;
		windFont.normal.textColor = Color.green;
		
		GUIStyle cloudFont = new GUIStyle();
		cloudFont.fontSize = 40;
		cloudFont.alignment = TextAnchor.MiddleCenter;
		cloudFont.normal.textColor = Color.magenta;

		if (beh.timerFireball >= Time.time)
		{
			DrawOutline(new Rect(posR.x - 25, Screen.height - posR.y - 25, 50, 50), (Mathf.Round (beh.timerFireball - Time.time)).ToString(), 1, fireFont);
		}

		if (beh.timerShockwave >= Time.time)
		{
			DrawOutline(new Rect(posB.x - 25, Screen.height - posB.y - 25, 50, 50), (Mathf.Round (beh.timerShockwave - Time.time)).ToString(), 1, shockwaveFont);
		}
		
		if (beh.timerTornado >= Time.time)
		{
			DrawOutline(new Rect(posG.x - 25, Screen.height - posG.y - 25, 50, 50), (Mathf.Round (beh.timerTornado - Time.time)).ToString(), 1, windFont);
		}
		
		if (beh.timerInvun >= Time.time)
		{
			DrawOutline(new Rect(posP.x - 25, Screen.height - posP.y - 25, 50, 50), (Mathf.Round (beh.timerInvun - Time.time)).ToString(), 1, cloudFont);
		}
	}

	// Update is called once per frame
	void Update () {
		redBG = GameObject.Find ("fireUnderlay");
		blueBG = GameObject.Find ("shockUnderlay");
		greenBG = GameObject.Find ("windUnderlay");
		purpleBG = GameObject.Find ("cloudUnderlay");
		posR = GetComponent<Camera>().WorldToScreenPoint (redBG.transform.position);
		posB = GetComponent<Camera>().WorldToScreenPoint (blueBG.transform.position);
		posG = GetComponent<Camera>().WorldToScreenPoint (greenBG.transform.position);
		posP = GetComponent<Camera>().WorldToScreenPoint (purpleBG.transform.position);
	}
}
