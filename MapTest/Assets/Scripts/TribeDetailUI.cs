using UnityEngine;
using System.Collections;

public class TribeDetailUI : MonoBehaviour {
	public Tribesman tribeMember;

	public GameObject nameText;
	public GameObject healthText;
	public GameObject ageText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void updateDisplay() {
		nameText.GetComponent<UnityEngine.UI.Text> ().text = tribeMember.Name;
		healthText.GetComponent<UnityEngine.UI.Text> ().text = tribeMember.Health.ToString();
		ageText.GetComponent<UnityEngine.UI.Text> ().text = tribeMember.Age.ToString();

	}
}
