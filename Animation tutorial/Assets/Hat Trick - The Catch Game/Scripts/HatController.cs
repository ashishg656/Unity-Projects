using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatController : MonoBehaviour {

	public Camera cam;
	Rigidbody2D rb2d;
	Renderer render;

	private float maxWidth;

	// Use this for initialization
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}
		rb2d = GetComponent<Rigidbody2D> ();
		render = GetComponent<Renderer> ();

		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		// calculating the width of the hat object dynamically
		float hatWidth = render.bounds.extents.x;
		maxWidth = targetWidth.x - hatWidth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// called once per physics timestamp
	void FixedUpdate(){
		Vector3 rawPosition = cam.ScreenToWorldPoint (Input.mousePosition);
		Vector3 targetPosition = new Vector3 (rawPosition.x, 0f, 0f);

		targetPosition.x = Mathf.Clamp (targetPosition.x, -maxWidth, maxWidth);
		rb2d.MovePosition (targetPosition);
	}
}
