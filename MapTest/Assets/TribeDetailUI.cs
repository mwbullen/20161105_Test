using UnityEngine;
using System.Collections;

public class TribeDetailUI : MonoBehaviour {
	public Tribesman tribeMember;

	public GameObject nameText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void updateDisplay() {
		nameText.GetComponent<UnityEngine.UI.Text> ().text = tribeMember.Name;
	}
}
