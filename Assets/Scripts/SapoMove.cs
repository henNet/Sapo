using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SapoMove : MonoBehaviour {
	//= +
	public float verticalMove;
	private Vector3 initialPosition;
	private Animator anim;
	private Setas setaCima;
	private Setas setaBaixo;
	private Setas play_a;
	public bool celular;

	private Image vidas;
	private GameObject gameOver;
	private GameObject playAgain;
	private GameObject pontosFinal;
	private Sprite[] sprites;
	private int life = 3; 
	private bool play = true;
	public int pontuacao = 0;
	private Image pontUI;
	private Image pontUIFinal;

	//Teste
	public Text pt;

	// Use this for initialization
	void Start () {
		//verticalMove = 1.0f;
		initialPosition = transform.position;
		anim = GetComponent<Animator>();
		//celular = false;

		setaCima = GameObject.FindWithTag ("seta_cima").GetComponent<Setas> ();
		setaBaixo = GameObject.FindWithTag ("seta_baixo").GetComponent<Setas> ();

		vidas = GameObject.FindWithTag ("count_life").GetComponent<Image> ();
		gameOver = GameObject.FindWithTag ("game_over");
		gameOver.SetActive (false);
		playAgain = GameObject.FindWithTag ("play_again");
		playAgain.SetActive (false);
		play_a = playAgain.GetComponent<Setas> ();
		sprites = Resources.LoadAll<Sprite>("letras");
		pontUI = GameObject.FindWithTag ("pontos").GetComponent<Image> ();
		pontosFinal = GameObject.FindWithTag ("pontos_final");
		pontosFinal.SetActive (false);
		//pontUIFinal = GameObject.FindWithTag("fpontos").GetComponent<Image>();
		pontUIFinal = pontosFinal.transform.GetChild(0).GetComponent<Image>();

		pt.text = "Pontos: 0";
	}

	// Update is called once per frame
	void Update () {

		if (play == true) {
			//if (celular == true)
				moveTouch ();
			//else
				moveKey ();
		}

		if (play_a.isSelected == true) {
			play = true;
			gameOver.SetActive(false);
			playAgain.SetActive (false);
			pontosFinal.SetActive (false);
			life = 3;
			play_a.isSelected = false;
			vidas.sprite = sprites[life];
			pontUI.sprite = sprites[0];
			pontuacao = 0;
		}
	}

	public void moveTouch()
	{
		if(setaCima.isSelected == true) 
		{
			//anim.SetBool ("move", true);
			anim.SetTrigger("pular");

			this.transform.position = new Vector3(transform.position.x,
				transform.position.y + verticalMove, transform.position.z);
			
			setaCima.isSelected = false;
		}

		if (setaBaixo.isSelected == true) 
		{
			//anim.SetBool ("fmove", true);
			anim.SetTrigger("fpular");

			this.transform.position = new Vector3(transform.position.x,
				transform.position.y - verticalMove*0.6f, transform.position.z);

			setaBaixo.isSelected = false;
		}

		//if (AnimationIsPlaying ("f_jump")) {
		//	anim.SetBool ("fmove", true);
		//	Debug.Log ("AQUI");
		//}else
			//anim.SetBool ("fmove", false);
		if (setaBaixo.isSelected == false) {
			anim.SetBool ("fmove", false);
		}
	}

	public void moveKey()
	{
		if (Input.GetKeyDown(KeyCode.UpArrow)) 
		{
			//anim.SetBool ("move", true);
			anim.SetTrigger("pular");

			this.transform.position = new Vector3(transform.position.x,
				transform.position.y + verticalMove, transform.position.z);

		}

		if (Input.GetKeyDown(KeyCode.DownArrow)) 
		{
			//anim.SetBool ("fmove", true);
			anim.SetTrigger("fpular");

			this.transform.position = new Vector3(transform.position.x,
				transform.position.y - verticalMove, transform.position.z);
		}
	}

	void OnTriggerEnter2D(Collider2D objeto)
	{
		if (objeto.gameObject.tag == "carros_2") 
		{
			//Debug.Log ("Colidiu");
			transform.position = initialPosition;
			life--;
			//Debug.Log ("Qt. Sprites: " + sprites.Length );

			if (life == 0) {
				Debug.Log ("GAME OVER");
				gameOver.SetActive(true);
				playAgain.SetActive (true);
				pontosFinal.SetActive (true);
				play = false;
				vidas.sprite = sprites[0];
				pontUIFinal.sprite = sprites[pontuacao];
				Debug.Log("Pontos: " + pontuacao);
			}else
				vidas.sprite = sprites[life];
		}

		if (objeto.gameObject.tag == "bee") {
			pontuacao++;
			pontUI.sprite = sprites[pontuacao];
			transform.position = initialPosition;

			pt.text = "Pontos: " + pontuacao;
		}

		if (objeto.gameObject.tag == "limite_inferior") 
		{
			transform.position = initialPosition;
		}
	}
}
