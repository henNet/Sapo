using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarroMove : MonoBehaviour {

	private float speed;
	private Vector3 initialPosition;
	private int pontuacaoC;

	// Use this for initialization
	void Start () {
		//speed = 0.5f;
		speed = Random.Range(0.5f, 2.5f);
		initialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		pontuacaoC = GameObject.FindWithTag("sapo").GetComponent<SapoMove>().pontuacao;

		if(pontuacaoC == 0)
			pontuacaoC++;
		
		transform.position = new Vector3 (transform.position.x - speed * Time.deltaTime * pontuacaoC,
				transform.position.y, transform.position.z);
		

		//Debug.Log("Pontos: " + pontuacaoC);
	}

	void OnTriggerExit2D(Collider2D objeto)
	{
		if (objeto.gameObject.tag == "rua") 
		{
			//Debug.Log ("SAIU");
			transform.position = initialPosition;
			speed = Random.Range(0.5f, 2.5f);
		}
	}
}
