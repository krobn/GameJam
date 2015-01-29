using UnityEngine;
using System.Collections;

public class BotonBack : MonoBehaviour {
	public string NextScene;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		Application.LoadLevel (NextScene);
	}
}
