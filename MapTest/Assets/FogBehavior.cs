﻿using UnityEngine;
using System.Collections;

public class FogBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider c) {
		if (c.gameObject.tag == "Character") {
			GameObject.Destroy (this.gameObject);
		}
	}
}
