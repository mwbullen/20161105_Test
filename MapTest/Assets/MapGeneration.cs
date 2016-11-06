using UnityEngine;
using System.Collections;


public class MapGeneration : MonoBehaviour {
	public int rowSize = 200;
	public int numberRows = 10;

	public float waterChance = .1f;
	public float waterAdjacentBonus;

	public float mountainChance = .1f;

	public string mapString;
	public GameObject mapParentPrefab;

	GameObject mapParentObject;

	//public GameObject openTilePrefab;
	public GameObject waterTilePrefab;
	public GameObject mountainTilePrefab;
	public GameObject treeTilePrefab;

	//public ArrayList mapDefinition = new ArrayList();

	// Use this for initialization
	void Start () {
		//UnityEngine.Debug.Log("test");

		mapString = PlayerPrefs.GetString ("MapDefinitionStr");

		if (mapString == null) {
			createMapString ();
		}

		generateMap ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void refreshMap() {
		createMapString ();
		generateMap ();
	}

	void createMapString() {
		//mapDefinition.Clear ();
		mapString = "";

		for (int i = 0; i < ((rowSize * numberRows)-1); i ++) {
			char c = '_';

			//check for water
			float tileCheckF = Random.Range (0f, 1f);

			float tmpWaterChance = waterChance;

			//check for adjacent tiles

			if (getTileStringatPosition (i - 1) == 'w') {
				tmpWaterChance = tmpWaterChance +waterAdjacentBonus;
			}

			if (getTileStringatPosition (i - rowSize) == 'w') {
				tmpWaterChance = tmpWaterChance  +waterAdjacentBonus;
			}

			//UnityEngine.Debug.Log(tileCheckF);
			if (tileCheckF < tmpWaterChance) {
				//water tile
				c = 'w';
			} 

			//mapDefinition.Add (c);
			mapString = mapString + c;

			PlayerPrefs.SetString ("MapDefinitionStr", mapString);
		}
	}

	char getTileStringatPosition(int position) {
		if (position > 0) {
			//return mapDefinition [position].ToString();
			return mapString[position];
		} else {
			return ' ';
		}
	}

	void generateMap() {
		if (mapParentObject != null) {
			GameObject.Destroy (mapParentObject);
		}

		mapParentObject = GameObject.Instantiate (mapParentPrefab);

		float counter = 0;
		float posx = 0;
		float posz = 0;

		foreach (char c in mapString) {
			GameObject tilePrefab = null;

			//read string and assign prefab
			if (c == 'w') {
				tilePrefab = waterTilePrefab;
			}

			//wrap row if row limit reached
			if (posx > rowSize) {
				posx = 0;
				posz += 1;
			}

			if (tilePrefab != null) {
				GameObject newTile = GameObject.Instantiate (tilePrefab);
				newTile.transform.parent = mapParentObject.transform;
				newTile.transform.Rotate (new Vector3 (90, 0, 0));
				newTile.transform.position = new Vector3 (posx, 0, posz);

			}
			posx += 1;
			counter += 1;
		}
	}


}
