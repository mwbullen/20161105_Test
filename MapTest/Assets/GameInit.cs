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

		Camera.main.SendMessage ("SetFollowTarget", newTribe);
	}
}
