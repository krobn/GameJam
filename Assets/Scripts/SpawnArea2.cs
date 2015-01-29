using UnityEngine;
using System.Collections;

public class SpawnArea2 : MonoBehaviour {

	public GameObject target;
	public int cantidad=10;
    public bool ready;
	public int contador;
	public int valorRandom;
	private Vector2 posicionSpawn;
	public float esperar = 0;
	public float distCam;
	private float tiempoini;
	public GameObject zombieNormal;
	public GameObject zombieRapido;
	public GameObject zombieResistente;
	public float tiempoLim;

	// Use this for initialization
	void Start () {
		tiempoini = Time.time;
	}  
	
	// Update is called once per frame
	void Update () 
	{
		esperar = Time.time - tiempoini;
		if (ready && esperar >= tiempoLim)
		{
			if ( contador <= cantidad )	{ //Create a new enemy
				valorRandom = Random.Range(0,10);
				//Clone of the enemy
				//spawning the enemy at position
				if ( valorRandom < 5 )                                              //cambiar camara por target  target.transform.position.x-60     
					posicionSpawn = new Vector2(Camera.main.gameObject.transform.position.x-distCam ,target.transform.position.y);
				else
					posicionSpawn = new Vector2(Camera.main.gameObject.transform.position.x+distCam,target.transform.position.y);

				valorRandom=Random.Range(0,10);
				CrearUnZombie(valorRandom,posicionSpawn);
				contador++;
				tiempoini = Time.time;
			}
		}
	}

	void CrearUnZombie(int valorRandom, Vector2 posicion){

		GameObject Clone;			
		if (valorRandom < 5)
			Clone = (Instantiate(zombieNormal, posicion , target.transform.rotation)) as GameObject;
		else {
			if (valorRandom > 5 && valorRandom < 8  )
				Clone = (Instantiate(zombieRapido, posicion , target.transform.rotation)) as GameObject;
			else
				Clone = (Instantiate(zombieResistente, posicion , target.transform.rotation)) as GameObject;

		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Personaje"){
			if (ready == false){
				 ready = true;
							   }
		}
	}

}
