﻿using UnityEngine;
using System.Collections;
using HutongGames.PlayMaker;

public class TribeMovement : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void MovetoTile(GameObject targetTile ) {		
		PlayMakerFSM movementFsm = gameObject.GetComponent<PlayMakerFSM> ();

		movementFsm.FsmVariables.GetFsmGameObject("targetTile").Value = targetTile;
		movementFsm.SendEvent ("Move to Tile");


	}
}
