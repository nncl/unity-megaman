using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour {

	public float velocidade;
	public float impulso;

	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		// Pulo
		if (Input.GetButtonDown("Jump")) {
			rb.AddForce (Vector2.up * impulso);
		}

		// Movimento
		float mover = Input.GetAxis("Horizontal") * velocidade * Time.deltaTime;
		transform.Translate (mover, 0.0f, 0.0f);
	}
}
