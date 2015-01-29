using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour {

	public KeyCode izquierda;
	public KeyCode derecha;
	public float velocidadMov=6f;
	private static bool corriendo;
	private static bool atacando;
	public int vidas=3;
	public float tiempini;
	public float tiempo;


	public GameObject bulletPrefab;
	public float velocidadBulletX;
	public float velocidadBulletY;
	public GameObject target;
	public Vector3 test;
	private Vector3 mouse_pos;
	//public Transform target; //Assign to the object you want to rotate
	private Vector3 object_pos;
	private float angle;
	public float offset;
	public float fuerX;
	public float fuerY;
	public float factorY;
	public float recoild;
	public float retardo=0.5f;


	private Animator animator;
	
	void Awake(){
		animator = GetComponent<Animator>();

	}

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void FixedUpdate () {

		if (tiempo >= retardo) {
			atacando=false;
				}
		if (Mathf.Abs(rigidbody2D.velocity.x) < 0.2f) {
			corriendo = false;		
		}
		mouse_pos = Input.mousePosition;
		object_pos = Camera.main.WorldToScreenPoint(transform.position);
		mouse_pos.x = mouse_pos.x - object_pos.x;
		if ((mouse_pos.x < 0 && transform.localScale.x > 0) || (mouse_pos.x >= 0 && transform.localScale.x < 0)) {
						transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
		}
		if(Input.GetKey(derecha)&&!atacando) 
		{
			rigidbody2D.velocity = new Vector2(velocidadMov,rigidbody2D.velocity.y);
			corriendo=true;
		}
		else if(Input.GetKey(izquierda)&&!atacando) 
		{
			rigidbody2D.velocity = new Vector2(-velocidadMov,rigidbody2D.velocity.y);
			corriendo=true;
			if(transform.localScale.x > 0){

				//SpawBalas.transform.localScale= new Vector3 (SpawBalas.transform.localScale.x * -1,SpawBalas.transform.localScale.y, SpawBalas.transform.localScale.z);
			}
		
		}

		//muevo arma

		mouse_pos = Input.mousePosition;
		mouse_pos.z = 5.23f; //The distance between the camera and object
		object_pos = Camera.main.WorldToScreenPoint(target.transform.position);
		mouse_pos.x = mouse_pos.x - object_pos.x;
		mouse_pos.y = mouse_pos.y - object_pos.y;
		angle = Mathf.Atan2(mouse_pos.y  , mouse_pos.x * transform.localScale.x) * Mathf.Rad2Deg ;
		
		
		if (angle < 1f) {
			angle = 1f;	
		} else if (angle > 40f) {
			angle = 40f;
		}
		target.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
		
		if (Input.GetMouseButtonDown(0)&&!corriendo&&!atacando){//when the left mouse button is clicked
			FireBullet();//look for and use the fire bullet operation
			tiempini=Time.time;
			atacando=true;
		}
	}
	
	
	
	public void FireBullet(){
		
				//Clone of the bullet
				GameObject Clone;
		
				//spawning the bullet at position
				Clone = (Instantiate (bulletPrefab, new Vector3 (target.transform.position.x + (offset * transform.localScale.x), target.transform.position.y, target.transform.position.z), target.transform.rotation)) as GameObject;
				//Clone.transform.localScale = personaje.transform.localScale;

				//add force to the spawned objected
		
				//Clone.rigidbody2D.AddRelativeForce (new Vector2 (velocidadBullet, 0));
				fuerX = (velocidadBulletX + velocidadBulletX * (Mathf.Abs (1 - target.transform.localRotation.z * 100 / 40))) * transform.localScale.x;
				//fuerX = velocidadBulletX* personaje.transform.localScale.x ;
				fuerY = 1 + factorY * velocidadBulletY * Mathf.Abs ((target.transform.localRotation.z * 100 / 40));
				Clone.rigidbody2D.velocity = new Vector2 (fuerX, fuerY);

				rigidbody2D.AddForce (new Vector2( recoild* -transform.localScale.x, 0));
				test = Clone.transform.forward;
		}

	
	void Update ()
	{
		
		animator.SetBool("estoyCaminado", corriendo);
		animator.SetBool("Atacando", atacando);	
		tiempo = Time.time - tiempini;

	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "BulletEnemy")
		{
			Destroy(other.gameObject);
			vidas--;
		}
		else if(other.gameObject.tag == "ZombieLento")
		{
			vidas-=4;
		}
		else if(other.gameObject.tag == "ZombieNormal")
		{
			vidas-=3;
		}
		else if(other.gameObject.tag == "ZombieRapido")
		{
			vidas-=2;
		}
		else if(other.gameObject.tag == "Nave")
		{
			vidas-=5;
		}


		if (vidas <= 0) {
						Destroy (gameObject);
			Application.LoadLevel ("Nivel1");
				}


	}


}

