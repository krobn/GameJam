	using UnityEngine;
	using System.Collections;

	public class ZombieController : MonoBehaviour {

		public float nivelDeMalo = 1.66f;
		public GameObject player;
		private float velocidadAux;
		private bool corriendo=false;
		private bool izq;
		private float distancia;
		private float modulo;
		public Vector2 test;
		public bool atacar;
		public int vida;
		public float velocidad;
		public float fuerza;
		
		// Use this for initialization
		void Start () {


			velocidadAux = velocidad;

		}

		// Update is called once per frame
		void Update () {

		}

		void FixedUpdate () 
			{
			corriendo = false;
			izq = false;
			distancia = transform.position.x - player.transform.position.x;
			modulo = Mathf.Abs (distancia);
			if ( distancia >= 0f) 
					izq = true;
			/*if ( modulo < 20f)
				velocidadAux = nivelDeMalo * velocidad ;
			if ( modulo <= 4f)
				velocidadAux = 0f ;*/

			if(izq)
			{
				rigidbody2D.velocity = new Vector2(-velocidadAux,rigidbody2D.velocity.y);
				corriendo=true;
				if(transform.localScale.x < 0){
					transform.localScale= new Vector3 (transform.localScale.x * -1,transform.localScale.y, transform.localScale.z);
				} 
			}
			else 
			{
				rigidbody2D.velocity = new Vector2(velocidadAux,rigidbody2D.velocity.y);
				corriendo=true;
				if(transform.localScale.x > 0){
					transform.localScale= new Vector3 (transform.localScale.x * -1,transform.localScale.y, transform.localScale.z);
				}
			}

		}

		void OnTriggerEnter2D(Collider2D other)
		{
			if(other.gameObject.tag == "Bullet")
			{
				Destroy(other.gameObject);
				vida--;
				if(vida==0)
					Destroy(gameObject);
			}
			if (other.gameObject.tag == "Personaje") {
				atacar	= true;

		
		}

		}
	void Awake(){}

	}
