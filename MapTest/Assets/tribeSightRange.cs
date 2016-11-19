using UnityEngine;
using System.Collections;

public class tribeSightRange : MonoBehaviour {

	public float sightRange =3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void updateTilesInRange() {

		foreach (int tileIndex in getTilesIndexesinRange()) {

		}
	}

	int[] getTilesIndexesinRange() {
		return null;
	}
}
