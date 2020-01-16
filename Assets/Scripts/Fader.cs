using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour
{
	public float duration;
	public bool fadeIn;
	public float startTime;
	
	void Start ()
	{
		fadeIn = false;
		startTime = Time.time;
		duration = 0f;
		this.gameObject.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 0f);
	}
	
	void Update ()
	{
		if (fadeIn)
		{
			if (Time.time <= duration)
			{
				this.gameObject.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, Time.time - duration + 1f);
			}
		}
	}
}
