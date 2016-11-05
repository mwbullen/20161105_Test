using UnityEngine;
using System.Collections;


public class MapGeneration : MonoBehaviour {
	public int rowSize = 200;
	public int numberRows = 10;

	public float waterChance = .1f;
	public float mountainChance = .1f;

	public string mapString;

	public ArrayList mapDefinition = new ArrayList();

	// Use this for initialization
	void Start () {
		UnityEngine.Debug.Log("test");

		createMapString ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void createMapString() {
		mapDefinition.Clear ();

		for (int i = 0; i < (rowSize * numberRows); i ++) {
			char c = '_';

			//check for water
			float tileCheckF = Random.Range (0f, 1f);

			float tmpWaterChance = waterChance;

			//check for adjacent tiles

			if (getTileStringatPosition (i - 1) == "w") {
				tmpWaterChance = tmpWaterChance * 2;
			}

			if (getTileStringatPosition (i - rowSize) == "w") {
				tmpWaterChance = tmpWaterChance * 2;
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

	}
}
