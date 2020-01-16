using UnityEngine;
using System.Collections;

public class OpacityChange : MonoBehaviour
{
	private GameObject player;
	private GameObject[] shaders;
	private GameObject[] shadersL;
	private GameObject[] bordersL;
	private PlayerBehaviour script;
	
	void Start ()
	{
		shaders = new GameObject[4];
		shadersL = new GameObject[4];
		bordersL = new GameObject[4];
		
		shaders[0] = GameObject.Find ("fireShader");
		shaders[1] = GameObject.Find ("shockShader");
		shaders[2] = GameObject.Find ("windShader");
		shaders[3] = GameObject.Find ("cloudShader");
		
		shadersL[0] = GameObject.Find ("fireShaderL");
		shadersL[1] = GameObject.Find ("shockShaderL");
		shadersL[2] = GameObject.Find ("windShaderL");
		shadersL[3] = GameObject.Find ("cloudShaderL");
		
		bordersL[0] = GameObject.Find ("fireBorderL");
		bordersL[1] = GameObject.Find ("shockBorderL");
		bordersL[2] = GameObject.Find ("windBorderL");
		bordersL[3] = GameObject.Find ("cloudBorderL");
		
		player = GameObject.Find ("Player");
		script = player.GetComponent<PlayerBehaviour>();
	}
	
	void Update ()
	{
		
		shaders[0].gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.7f);
		shaders[1].gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.7f);
		shaders[2].gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.7f);
		shaders[3].gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.7f);
		
		shadersL[0].gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0f);
		shadersL[1].gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0f);
		shadersL[2].gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0f);
		shadersL[3].gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0f);
		
		bordersL[0].gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0f);
		bordersL[1].gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0f);
		bordersL[2].gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0f);
		bordersL[3].gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0f);
		
		shaders[script.currentDim - 1].gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.3f);
		bordersL[script.currentDim - 1].gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 2.0f);

		if (script.timerFireball >= Time.time)
		{
			shadersL[0].gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.4f);
		}

		if (script.timerShockwave >= Time.time)
		{
			shadersL[1].gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.4f);
		}
		
		if (script.timerInvun >= Time.time)
		{
			shadersL[3].gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.4f);
		}
	}
}