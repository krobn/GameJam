using UnityEngine;
using System.Collections;

public class NaveController : MonoBehaviour {


	public float distanciaDelCentro = 45; 
	public float lentitud = 0.3f;
	public Transform player;
	public float velocidadMov=15f;
	public int vidas=5;
	public GameObject rayo;

	public float velocidad;
	public bool izq=false;
	public float distancia;
	public float modulo;
	private int cantLento;
	private bool lento = false;
	private float tiempoIni;
	private float tiempo;
	private float tiempoIniRayo;
	private float tiempoRayo;
	private bool activado=false;
	public float distanciaDisparo;
	public float test1;
	// Use this for initialization
	void Start () {

		tiempoIni = Time.time;
		rayo.SetActive (false);
		activado = false;
		//distancia = transform.position.x - player.transform.position.x;
		velocidad = velocidadMov;
		//if ( distancia >= 0f) 
		//	izq = true;

	}


	void Update () 
	{	tiempo = Time.time - tiempoIni;
		if((tiempo >= 1.08f) && (activado)){
			activado=false;
			rayo.SetActive (false);
		
		}
	}

	void FixedUpdate () 
	{

		test1 = player.position.x;
		if ( lento == true ) {
		cantLento--;
			if ( cantLento == 0 ){
			lento = false;
			velocidad = velocidadMov;
			}
		}

		distancia = transform.position.x - player.position.x;
		modulo = Mathf.Abs (distancia);


		if (( modulo < distanciaDisparo) && ( lento == false ))  {
			velocidad= lentitud * velocidadMov ;
			cantLento = 200;  
			lento = true; 
			DispararLaser();  
		}  

		if ( gameObject.transform.position.x <= Camera.main.gameObject.transform.position.x-distanciaDelCentro ) //se me va a la izquierda
			{ izq = false;
			  	}

		if ( gameObject.transform.position.x >= Camera.main.gameObject.transform.position.x+distanciaDelCentro ) //se me va a la derecha
		{ izq = true;
			}
		
		if(izq)
			{ MoverIzquierda(); }
		else   //derecha
			{ MoverDerecha(); }

	}

	void MoverIzquierda() {
		rigidbody2D.velocity = new Vector2(-velocidad,0f);
		//if(transform.localScale.x < 0)
		//	transform.localScale= new Vector3 (transform.localScale.x * -1,transform.localScale.y, transform.localScale.z);
	}
	
	void MoverDerecha() {
		rigidbody2D.velocity = new Vector2(velocidad,0f);
		//if(transform.localScale.x > 0){
		//	transform.localScale= new Vector3 (transform.localScale.x * -1,transform.localScale.y, transform.localScale.z);
		//}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Bullet")
		{
			Destroy(other.gameObject);
			vidas--;
			if(vidas==0)
				Destroy(gameObject);
		}
	}
	
	void DispararLaser(){

		rayo.SetActive (true);
		activado = true;
		tiempoIni = Time.time;
		//Clone of the bullet
		//GameObject Clone;
		

				//Clone = (Instantiate(disparoLaser, Nave.transform.position,Nave.transform.rotation)) as GameObject;
				//add force to the spawned objected
				//Clone.rigidbody2D.AddRelativeForce(new Vector2(0f,-velocidadLaser)); 
	} 
		
		




	}

