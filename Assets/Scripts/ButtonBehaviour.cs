using UnityEngine;
using System.Collections;

public class ButtonBehaviour : MonoBehaviour
{
	Texture2D cursor;
	GameObject instructions;
	GameObject back1;
	GameObject back2;
	GameObject temp;
	GameObject credits;
	Fader script;
	Fader script2;
	Fader script3;
	Fader script4;

	GameObject click;
	GameObject hover;
	
	void Start ()
	{
		instructions = GameObject.Find ("Instructions");
		back1 = GameObject.Find ("Back Normal");
		back2 = GameObject.Find ("Back Hover");
		credits = GameObject.Find ("Credits");

		click = GameObject.Find ("Click");
		hover = GameObject.Find ("Hover");
		
		temp = GameObject.Find (this.gameObject.name.Split (' ')[0] + " Normal");
		
		if (this.gameObject.name.Split (' ')[1] == "Hover")
		{
			this.gameObject.GetComponent<Renderer>().enabled = false;
		}
		else
		{
			this.gameObject.GetComponent<Renderer>().enabled = true;
		}
		
		cursor = (Texture2D)Resources.Load ("cursor.jpg");
		script = instructions.GetComponent<Fader>();
		script2 = back1.GetComponent<Fader>();
		script3 = back2.GetComponent<Fader>();
		script4 = credits.GetComponent<Fader>();
	}

	void OnMouseEnter() {
		hover.GetComponent<AudioSource> ().Play ();
	}

	void OnMouseOver()
	{

		Cursor.SetCursor (cursor, Vector2.zero, CursorMode.Auto);
		
		if (this.gameObject.name.Split (' ')[1] == "Hover")
		{
			this.gameObject.GetComponent<Renderer>().enabled = true;
			temp.gameObject.GetComponent<Renderer>().enabled = false;
		}
		
		if (Input.GetMouseButtonDown (0))
		{
			click.GetComponent<AudioSource> ().Play ();
			switch (this.gameObject.name)
			{
				case "Play Hover" :
					Invoke ("load", 0.2F);
				break;
				
				case "Instructions Hover" :
					instructions.transform.position = new Vector3 (0, 0, -2);
					script.fadeIn = true;
					script.duration = Time.time + 0.5f;
					script2.fadeIn = true;
					script2.duration = Time.time + 0.5f;
					script3.fadeIn = true;
					script3.duration = Time.time + 0.5f;
				break;
					
				case "Credits Hover" :
					credits.transform.position = new Vector3 (0, 0, -2);
					script4.fadeIn = true;
					script4.duration = Time.time + 0.5f;
					script2.fadeIn = true;
					script2.duration = Time.time + 0.5f;
					script3.fadeIn = true;
					script3.duration = Time.time + 0.5f;
				break;
				
				case "Back Hover" :
					instructions.transform.position = new Vector3 (0, 0, 2);
					credits.transform.position = new Vector3 (0, 0, 2);
					script.fadeIn = false;
					script4.fadeIn = false;
					script.duration = Time.time + 0.5f;
					script2.fadeIn = false;
					script2.duration = Time.time + 0.5f;
					script3.fadeIn = false;
					script3.duration = Time.time + 0.5f;
					back1.gameObject.GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f, 0f);
					back2.gameObject.GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f, 0f);
				break;
				
				case "Exit Hover" :
					Application.Quit();
				break;
			}
		}
	}
	
	void OnMouseExit()
	{		
		Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
		
		if (this.gameObject.name.Split (' ')[1] == "Hover")
		{
			this.gameObject.GetComponent<Renderer>().enabled = false;
			temp.gameObject.GetComponent<Renderer>().enabled = true;
		}
	}

	void load() {
		Application.LoadLevel("Level1");
	}
	
	void Update ()
	{
		
	}
}
