using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

	public float followDistance;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject tribe = gameObject.transform.parent.gameObject;
		TribeInfo tribeInfo = tribe.GetComponent<TribeInfo>();

		GameObject chief = tribeInfo.Chief;

		//if not the chief
		if (chief != gameObject) {
			float distanceToChief = Vector3.Distance (chief.transform.position, gameObject.transform.position);

			NavMeshAgent navAgent = gameObject.GetComponent<NavMeshAgent> ();

			if (distanceToChief > followDistance ) {
				gameObject.SendMessage ("NavtoPoint", chief.transform.position);
			}
		}

	}
}
