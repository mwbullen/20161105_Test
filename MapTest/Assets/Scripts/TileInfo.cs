using UnityEngine;
using System.Collections;

public class TileInfo : MonoBehaviour {

	public int TileID;

	public bool Walkable;

	public float foodChance = 0;
	public bool hasFood = false;

	GameObject foodObject;

	// Use this for initialization
	void Start () {
		GameObject gameControl = GameObject.FindGameObjectWithTag ("GameControl");

		float foodTest = Random.Range (0, 100);

		if (foodTest < foodChance) {
			//add food
			hasFood = true;

			GameObject foodPreFab = gameControl.GetComponent<MapGeneration> ().foodPrefab;

			foodObject = GameObject.Instantiate (foodPreFab);
			foodObject.transform.parent = gameObject.transform;
			foodObject.transform.localPosition = new Vector3 (0, 0, 0);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
