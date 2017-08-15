/**
 * https://www.youtube.com/channel/UCFfoB07rP9kBf_7DC9ez_lQ
 **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour {

	public float velocidade;
	public float impulso;
	public Transform verificaChao;
	public SpriteRenderer sp;
	bool estaNoChao;
	bool puloDuplo;

	Animator animar;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		animar = GetComponent<Animator> ();
		sp = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {

		// Pulo
		if (Input.GetButtonDown("Jump") && estaNoChao) {
			rb.AddForce (Vector2.up * impulso);
			puloDuplo = true;
		} else if (Input.GetButtonDown("Jump") && !estaNoChao && puloDuplo) {
			rb.AddForce (Vector2.up * impulso);
			puloDuplo = false;
		}

		// Movimento
		float mover = Input.GetAxis("Horizontal") * velocidade * Time.deltaTime;
		transform.Translate (mover, 0.0f, 0.0f);

		// Verifica colisão com os blocos do layer Piso
		estaNoChao = Physics2D.Linecast(transform.position, 
			verificaChao.position, 
			1 << LayerMask.NameToLayer("Piso"));

		// Animações
		animar.SetBool("pJump", estaNoChao);
		animar.SetFloat ("pMove", Mathf.Abs(Input.GetAxisRaw("Horizontal")));

		// Orientação do personagem
		if (Input.GetAxisRaw("Horizontal") > 0.0f) {
			sp.flipX = false;
		} else if (Input.GetAxisRaw("Horizontal") < 0.0f) {
			sp.flipX = true;
		}
	}
}
