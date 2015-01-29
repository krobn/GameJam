using UnityEngine;
using System.Collections;

public class FireEnemyScript : MonoBehaviour {

	//the object that will be spawned
	
	public GameObject bulletPrefab;
	public float velocidadBullet;
	public GameObject target;
	public Vector3 test;
	public int i ;
	public int limteRandom;
	
	public GameObject personaje;
	
	
	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		 i = Random.Range(1,2000);
		if(i < limteRandom)
		{
			
			print ("dispara enemigo");//print a message to act as a debug

			FireBullet();//look for and use the fire bullet operation
			
		}
	}
	
	
	
	public void FireBullet(){
		
		//Clone of the bullet
		GameObject Clone;
		
		//spawning the bullet at position
		Clone = (Instantiate(bulletPrefab, transform.position,transform.rotation)) as GameObject;
		Debug.Log ("Bullet is found");
		//Clone.transform.localScale = personaje.transform.localScale;
		
		
		//add force to the spawned objected
		
		Clone.rigidbody2D.AddRelativeForce (new Vector2 (0,-velocidadBullet));
		
		
		Debug.Log ("Force is added");
		
		test = Clone.transform.forward;
		
		
	}
}
