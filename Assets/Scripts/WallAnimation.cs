using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WallAnimation : MonoBehaviour {

	public int dimSetting;
	private int currentDim;
	private MeshRenderer mesh;
	public List<Material> materials;

	// Use this for initialization
	void Start () {
		mesh = GetComponent<MeshRenderer> ();

		/*switch (dimSetting) {
			case 1:
				anim.Play ("Dimension1");
				break;
			case 2:
				anim.Play ("Dimension2");
				break;
			case 3:
				anim.Play ("Dimension3");
				break;
			case 4:
				anim.Play ("Dimension4");
				break;
			default:
				anim.Play ("Dimension1");
				break;
		}*/

		mesh.material = materials[dimSetting - 1];

		currentDim = 1;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.A)) {
			currentDim = 1;
		}

		if (Input.GetKeyDown (KeyCode.W)) {
			currentDim = 2;
		}

		if (Input.GetKeyDown (KeyCode.E)) {
			currentDim = 3;
		}

		if (Input.GetKeyDown (KeyCode.R)) {
			currentDim = 4;
		}

		if (currentDim == dimSetting) {
			this.gameObject.GetComponent<Renderer>().material.color = new Color(1.0f,1.0f,1.0f,1.0f);
			this.gameObject.GetComponent<Collider2D>().enabled = true;
		} else {
			this.gameObject.GetComponent<Renderer>().material.color = new Color(1.0f,1.0f,1.0f,0.2f);
			this.gameObject.GetComponent<Collider2D>().enabled = false;
		}
	}
}
