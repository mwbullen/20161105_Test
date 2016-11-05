﻿using UnityEngine;
using System.Collections;


public class MapGeneration : MonoBehaviour {
	public int rowSize = 200;
	public int numberRows = 10;

	public float waterChance = .1f;
	public float waterAdjacentBonus;

	public float mountainChance = .1f;

	public string mapString;
	public GameObject mapParentObject;

	public GameObject openTilePrefab;
	public GameObject waterTilePrefab;
	public GameObject mountainTilePrefab;
	public GameObject treeTilePrefab;

	public ArrayList mapDefinition = new ArrayList();

	// Use this for initialization
	void Start () {
		UnityEngine.Debug.Log("test");

		createMapString ();

		generateMap ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void createMapString() {
		mapDefinition.Clear ();

		for (int i = 0; i < ((rowSize * numberRows)-1); i ++) {
			char c = '_';

			//check for water
			float tileCheckF = Random.Range (0f, 1f);

			float tmpWaterChance = waterChance;

			//check for adjacent tiles

			if (getTileStringatPosition (i - 1) == "w") {
				tmpWaterChance = tmpWaterChance +waterAdjacentBonus;
			}

			if (getTileStringatPosition (i - rowSize) == "w") {
				tmpWaterChance = tmpWaterChance  +waterAdjacentBonus;
			}

			//UnityEngine.Debug.Log(tileCheckF);
			if (tileCheckF < tmpWaterChance) {
				//water tile
				c = 'w';
			} 

			mapDefinition.Add (c);
			mapString = mapString + c;
		}
	}

	string getTileStringatPosition(int position) {
		if (position > 0) {
			return mapDefinition [position].ToString();
		} else {
			return "";
		}
	}

	void generateMap() {


		float counter = 0;
		float posx = 0;
		float posz = 0;

		foreach (char c in mapDefinition) {
			

			GameObject tilePrefab = openTilePrefab;

			if (c == 'w') {
				tilePrefab = waterTilePrefab;
			}

			if (posx > rowSize) {
				posx = 0;
				posz += 1;
			}
			GameObject newTile = GameObject.Instantiate (tilePrefab);
			newTile.transform.parent = mapParentObject.transform;
			newTile.transform.Rotate(new Vector3 (90, 0, 0));
			newTile.transform.position = new Vector3 (posx, 0, posz);

			posx += 1;
			counter += 1;
		}
	}


}
