using UnityEngine;
using System.Collections;

public class mapGenButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onButtonPress() {
		GameObject gameControl = GameObject.FindGameObjectWithTag ("GameControl");

		gameControl.SendMessage ("refreshMap");

	}
}
