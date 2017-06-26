using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour {

	Rigidbody2D rb2d;
	public float upForce = 200f;
	Animator anim;
	public bool isDead = false;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown (0) && !isDead) {
//			rb2d.velocity = //new Vector2 (0, 0); 
			rb2d.velocity = Vector2.zero;
			rb2d.AddForce (new Vector2 (0, upForce));

			anim.SetTrigger ("Flap");
		}
	}

	public void OnCollisionEnter2D(Collision2D other){
		anim.SetTrigger ("Die");
		isDead = true;
	}
}
