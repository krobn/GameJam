using UnityEngine;
using System.Collections;

public class Inicio : MonoBehaviour {
	public string NextScene;
	public float tiempoInicio;
	public float tiempo;
	// Use this for initialization
	void Start () {
		tiempoInicio = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		tiempo = Time.time - tiempoInicio;
		if (tiempo > 12.5f) {
			Application.LoadLevel (NextScene);
		}
	}
}
