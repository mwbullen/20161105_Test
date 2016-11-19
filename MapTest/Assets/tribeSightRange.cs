using UnityEngine;
using System.Collections;

public class tribeSightRange : MonoBehaviour {

	[HideInInspector] public GameObject GameControl;

	public float sightRange =3f;

	// Use this for initialization
	void Start () {
		GameControl = GameObject.FindGameObjectWithTag ("GameControl");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void updateTilesInRange() {

		foreach (int tileIndex in getTilesIndexesinRange()) {
			GameControl.SendMessage ("DisplayTile", tileIndex);
		}
	}

	int[] getTilesIndexesinRange() {
		GameObject currentTile = gameObject.GetComponent<TribeMovement> ().currentTile;

		//int[] inRangeTiles = {currentTile.GetComponent<TileInfo>().TileID };
		return null;
	}
}
