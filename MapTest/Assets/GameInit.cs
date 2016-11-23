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
}
