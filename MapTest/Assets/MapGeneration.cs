using UnityEngine;
using System.Collections;


public class MapGeneration : MonoBehaviour {
	public int rowSize = 200;
	public int numberRows = 10;

	public int waterChanceBase = 5;
	public int waterAdjacentBonus = 20;

	public int mtnChanceBase = 5;
	public int mtnAdjacentBonus = 20;

	public int treeChanceBase = 5;
	public int treeAdjacentBonus = 20;

	public int openChanceBase = 50;

	public string mapString;
	public GameObject mapParentPrefab;

	GameObject mapParentObject;

	public GameObject openTilePrefab;
	public GameObject waterTilePrefab;
	public GameObject mountainTilePrefab;
	public GameObject treeTilePrefab;

	//public ArrayList mapDefinition = new ArrayList();

	// Use this for initialization
	void Start () {
		//UnityEngine.Debug.Log("test");

		mapParentObject = GameObject.Instantiate (mapParentPrefab);


		mapString = PlayerPrefs.GetString ("MapDefinitionStr");

		if (mapString == null) {
			createMapString ();
		}


		gameObject.GetComponent<GameInit> ().CreateTribe ();

		/*for (int i = 1; i < 500; i++) {
			DisplayTile (i);
		}
		*/
		//generateMap ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void refreshMap() {
		createMapString ();
		generateMap ();
	}

	char getRandomMapCharforPos(int i) {
		int nextInterval = 0;

		//water
		int[] waterChanceArray = { nextInterval, waterChanceBase };

		if (getTileStringatPosition (i - 1) == 'w') {
			waterChanceArray[1] = waterChanceArray[1] +waterAdjacentBonus;
		}

		if (getTileStringatPosition (i - rowSize) == 'w') {
			waterChanceArray[1] = waterChanceArray[1]  +waterAdjacentBonus;
		}

		nextInterval = waterChanceArray[1] + 1;

		//tree
		int[] treeChanceArray = {nextInterval, nextInterval + treeChanceBase};

		if (getTileStringatPosition (i - 1) == 'T') {
				treeChanceArray[1] = treeChanceArray[1] +treeAdjacentBonus;
		}

		if (getTileStringatPosition (i - rowSize) == 'T') {
				treeChanceArray[1] = treeChanceArray[1]  +treeAdjacentBonus;
		}

		nextInterval = treeChanceArray[1] + 1;

		//mountain
		int[] mtnChanceArray = {nextInterval, nextInterval + mtnChanceBase};

		if (getTileStringatPosition (i - 1) == 'm') {
			mtnChanceArray[1] = mtnChanceArray[1] +mtnAdjacentBonus;
		}

		if (getTileStringatPosition (i - rowSize) == 'm') {
			mtnChanceArray[1] = mtnChanceArray[1]  +mtnAdjacentBonus;
		}

		nextInterval = mtnChanceArray[1] + 1;

		//open 

		int totalRange = nextInterval + openChanceBase;

		//generate random 
		int tileCheckInt = Random.Range (0, totalRange);

		if (waterChanceArray [0] <= tileCheckInt && tileCheckInt <= waterChanceArray [1]) {
			//water tile
			return 'w';
		} else if (treeChanceArray [0] <= tileCheckInt && tileCheckInt <= treeChanceArray [1]) {
			//tree tile
			return 'T';
		} else if (mtnChanceArray [0] <= tileCheckInt && tileCheckInt <= mtnChanceArray [1]) {
			//mountain tile
			return 'm';
		} else {
			//open (no) tile
			return '_';
		}

	}

	void createMapString() {
		//mapDefinition.Clear ();
		mapString = "";

		for (int i = 0; i < ((rowSize * numberRows)-1); i ++) {
			/*char c = '_';

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

			if (tileCheckF < tmpWaterChance) {
				c = 'w';
			} 
			*/

			char c = getRandomMapCharforPos (i);
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


	public GameObject DisplayTile(int tileIndex) {
		//check if tile exists

		foreach (GameObject tileGameObject in GameObject.FindGameObjectsWithTag("Tile")) {
			if (tileGameObject.GetComponent<TileInfo> ().TileID == tileIndex) {//tile is already displayed				
				return tileGameObject;
			} 
		}

		//if tile does not exist, display

		char tileChar = getTileStringatPosition (tileIndex);

		GameObject tilePrefab = null;

		//Debug.Log (tileIndex);
		//read string and assign prefab
		if (tileChar == '_') {
			tilePrefab = openTilePrefab;
		} else if (tileChar == 'w') {
			tilePrefab = waterTilePrefab;
		} else if (tileChar == 'T') {
			tilePrefab = treeTilePrefab;
		} else if (tileChar == 'm') {
			tilePrefab = mountainTilePrefab;
		}

		float posx =  tileIndex % rowSize;
		float posz = Mathf.Round (tileIndex /rowSize);

		//need to calculate coordinates
		GameObject newTile = GameObject.Instantiate (tilePrefab);
		newTile.GetComponent<TileInfo> ().TileID = tileIndex;

		newTile.transform.parent = mapParentObject.transform;
		newTile.transform.Rotate (new Vector3 (90, 0, 0));

		newTile.transform.position = new Vector3 (posx, 0, posz);

		return newTile;
	}

	void generateMap() {
		if (mapParentObject != null) {
			GameObject.Destroy (mapParentObject);
		}

		mapParentObject = GameObject.Instantiate (mapParentPrefab);

		float counter = 0;
		float posx = 0;
		float posz = 0;

		char[] mapStringChars = mapString.ToCharArray ();

		//foreach (char c in mapString) {

		for (int charIndex = 0; charIndex <= mapStringChars.Length; charIndex++) {
			char c = mapStringChars [charIndex];

			GameObject tilePrefab = null;

			//read string and assign prefab
			if (c == '_') {
				tilePrefab = openTilePrefab;
			} else if (c == 'w') {
				tilePrefab = waterTilePrefab;
			} else if (c == 'T') {
				tilePrefab = treeTilePrefab;
			} else if (c == 'm') {
				tilePrefab = mountainTilePrefab;
			}

			//wrap row if row limit reached
			if (posx > rowSize) {
				posx = 0;
				posz += 1;
			}

			if (tilePrefab != null) {
				GameObject newTile = GameObject.Instantiate (tilePrefab);
				newTile.GetComponent<TileInfo> ().TileID = charIndex;

				newTile.transform.parent = mapParentObject.transform;
				newTile.transform.Rotate (new Vector3 (90, 0, 0));
				newTile.transform.position = new Vector3 (posx, 0, posz);

			}
			posx += 1;
			counter += 1;
		}
	}


}
