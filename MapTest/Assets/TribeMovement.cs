using UnityEngine;
using System.Collections;
using HutongGames.PlayMaker;

public class TribeMovement : MonoBehaviour {

	//[HideInInspector] public GameObject currentTile;
	public int currentTileID = 125;
	GameObject gameControl;


	// Use this for initialization
	void Start () {
		gameControl = GameObject.FindGameObjectWithTag ("GameControl");

		SpawnatLastTile ();
	}


	void SpawnatLastTile() {
		GameObject lastTile = gameControl.GetComponent<MapGeneration> ().DisplayTile (currentTileID);

		gameObject.transform.position = lastTile.transform.position;

		//gameObject.GetComponent<tribeSightRange>().
	}

	// Update is called once per frame
	void Update () {
	}

	public void MovetoTile(GameObject targetTile ) {		
		PlayMakerFSM movementFsm = gameObject.GetComponent<PlayMakerFSM> ();

		movementFsm.FsmVariables.GetFsmGameObject("targetTile").Value = targetTile;
		movementFsm.SendEvent ("Move to Tile");

		currentTileID = targetTile.GetComponent<TileInfo> ().TileID;

		gameObject.SendMessage ("updateTilesInRange");
	}
}
