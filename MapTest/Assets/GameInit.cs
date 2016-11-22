using UnityEngine;
using System.Collections;

public class GameInit : MonoBehaviour {

	public GameObject tribePrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CreateTribe() {
		GameObject newTribe = GameObject.Instantiate (tribePrefab);

		//assign tribe prefab where needed
		Camera.main.SendMessage ("SetFollowTarget", newTribe);

		gameObject.GetComponent<mouseInput>().Tribe  = newTribe;
	}

	public GameObject getRandomOpenTile() {
		MapGeneration mapGen = gameObject.GetComponent<MapGeneration> ();

		GameObject targetTile = null;

		char[] mapChars = mapGen.mapString.ToCharArray ();

		while (targetTile == null) {
			int randomTileID = Random.Range (1, mapChars.Length);

			//get random tile char
			//if _, then set as Tribe start tileIndex
		}
	}
}
