using UnityEngine;
using System.Collections;

public class AlienControll: MonoBehaviour {
	
	public float nivelDeMalo = 1.66f;
	public Vector2 movimiento;
	public GameObject player;
	public float velocidadMov=2f;
	public int vidas=5;
	
	private float velocidadAux;
	private bool corriendo=false;
	private bool izq;
	private float distancia;
	private float modulo;
	// Use this for initialization
	void Start () {
		velocidadAux = velocidadMov;
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
		if ( modulo < 20f)
			velocidadAux = nivelDeMalo * velocidadMov ;
		if ( modulo <= 4f)
			velocidadAux = 0f ;
		
		if(izq)
		{
			rigidbody2D.velocity = new Vector2(-velocidadAux,0f);
			corriendo=true;
		}
		else 
		{
			rigidbody2D.velocity = new Vector2(velocidadAux,0f);
			
			
			corriendo=true;
		}
		movimiento = rigidbody2D.velocity;
		
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
	
	
}

