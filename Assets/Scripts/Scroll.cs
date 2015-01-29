using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {
	private float tiempoInicio = 0f;
	public float velocidad = 0f;
	public GameObject personaje;

	// Use this for initialization
	void Start () {	
		tiempoInicio = Time.time;

	}
	
	// Update is called once per frame
	void Update () {
		velocidad = rigidbody2D.velocity.x;
		renderer.material.mainTextureOffset = new Vector2(((Time.time - tiempoInicio) * velocidad) % 1, 0);
	

	}
}
