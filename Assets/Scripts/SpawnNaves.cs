using UnityEngine;
using System.Collections;

public class SpawnNaves : MonoBehaviour {
	
	public Transform target;
	public GameObject enemigo;
	public int cantidad=5;
	public bool ready;
	private int contador;
	public int valorRandom;
	private Vector2 posicionSpawn;
	public int esperar = 0;
	public float distanciaDeSpawn = 300f;
	public int alturaMin = 50;
	public int alturaMax = 80;
	private int altura;
	public static int primeraOleada; 
	public int oleadasRestantes = 2;
	private bool esperandoEntreOleadas = false;
	public int esperaEntreOleadas = 1000;
	
	void Start () {
		primeraOleada = cantidad;
	}
	
	// Update is called once per frame
	void Update () 
	{
		esperar++;
		if (esperandoEntreOleadas == true) {
			if (esperar >= esperaEntreOleadas)
				esperandoEntreOleadas = false; }
		if ((primeraOleada == 0) && (esperandoEntreOleadas == false)) {
			esperandoEntreOleadas = true;
			oleadasRestantes = oleadasRestantes - 1; 
			esperar = 0;}
		if ((ready == true) && (esperar >= 300) && (oleadasRestantes > 0) && (esperandoEntreOleadas == false))
		{
			if ( contador <= cantidad )	{ //Create a new enemy
				valorRandom = Random.Range(0,10);
				//Clone of the enemy
				//GameObject Clone;			
				//spawning the enemy at position
				altura = Random.Range(alturaMin,alturaMax);
				if ( valorRandom < 5 )                                  //spawn izquierda    
					posicionSpawn = new Vector2(Camera.main.gameObject.transform.position.x-distanciaDeSpawn ,altura);
				else                                                   //spawn derecha
					posicionSpawn = new Vector2(Camera.main.gameObject.transform.position.x+distanciaDeSpawn,altura);
				
				Instantiate(enemigo, posicionSpawn , target.transform.rotation) ;
				contador++;
				esperar = 0;
				//Clone.GetComponent("NaveController").player = target.transform;
			}
		}
	}
	
	void FixedUpdate () 
	{
		
	}
	
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Personaje"){
			if (ready == false){
				ready = true; }
		}
	}
	
}
