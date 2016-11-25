using UnityEngine;
using System.Collections;
using HutongGames.PlayMaker;

public class TribeMovement : MonoBehaviour {

	//[HideInInspector] public GameObject currentTile;
	public int currentTileID = 125;
	[HideInInspector] public int rowSize;

	GameObject gameControl;


	// Use this for initialization
	void Start () {
		gameControl = GameObject.FindGameObjectWithTag ("GameControl");

		rowSize = gameControl.GetComponent<MapGeneration> ().rowSize;

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

		//need to confirm target tile is walkable
		if (targetTile.GetComponent<TileInfo> ().Walkable) {
			movementFsm.FsmVariables.GetFsmGameObject ("targetTile").Value = targetTile;
			movementFsm.SendEvent ("Move to Tile");

			currentTileID = targetTile.GetComponent<TileInfo> ().TileID;

			gameObject.SendMessage ("updateTilesInRange");

			gameControl.GetComponent<SaveLoad> ().Save ();
			}
		}

	// Directional movement

	public void MoveUp() {
		int targetTileID = currentTileID + rowSize;

		MovetoTile (gameControl.GetComponent<MapGeneration> ().DisplayTile (targetTileID));

	}

	public void MoveDown() {
		int targetTileID = currentTileID - rowSize;

		MovetoTile (gameControl.GetComponent<MapGeneration> ().DisplayTile (targetTileID));

	}

	public void MoveLeft() {
		int targetTileID = currentTileID -1;

		MovetoTile (gameControl.GetComponent<MapGeneration> ().DisplayTile (targetTileID));

	}

	public void MoveRight() {
		int targetTileID = currentTileID + 1;

		MovetoTile (gameControl.GetComponent<MapGeneration> ().DisplayTile (targetTileID));

	}
}
