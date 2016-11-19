using UnityEngine;
using System.Collections;

public class tribeSightRange : MonoBehaviour {

	[HideInInspector] public GameObject GameControl;

	public int sightRange =3;

	// Use this for initialization
	void Start () {
		GameControl = GameObject.FindGameObjectWithTag ("GameControl");

		updateTilesInRange ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void updateTilesInRange() {

		foreach (int tileIndex in getTilesIndexesinRange()) {
			GameControl.SendMessage ("DisplayTile", tileIndex);
		}
	}

	ArrayList getTilesIndexesinRange() {
		
		int currentTileIndex = gameObject.GetComponent<TribeMovement> ().currentTileID;

		//int[] inRangeTiles = {currentTileIndex};

		ArrayList inRangeTileList = new ArrayList ();

		inRangeTileList.Add (currentTileIndex);


		for (int i = currentTileIndex - sightRange; i <= currentTileIndex + sightRange; i++) {
			if (i > 0) {
				inRangeTileList.Add (i);
			}
		}

		return inRangeTileList;
	}
}
