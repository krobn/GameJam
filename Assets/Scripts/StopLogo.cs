using UnityEngine;
using System.Collections;

public class StopLogo : MonoBehaviour {

	void update(){
		Example ();
		}
	void Example() {
		animation.Stop("LogoAnim");
	}
}