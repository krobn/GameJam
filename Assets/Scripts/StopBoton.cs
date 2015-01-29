using UnityEngine;
using System.Collections;

public class StopBoton : MonoBehaviour {

	void update(){
		Example ();
		}
	void Example() {
		animation.Stop("BotonPlay");
	}
}