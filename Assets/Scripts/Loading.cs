using UnityEngine;
using System.Collections;

public class Loading : MonoBehaviour {
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
		if (tiempo > 3f) {
			Application.LoadLevel (NextScene);
		}
	}
}
