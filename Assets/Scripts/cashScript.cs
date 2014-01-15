using UnityEngine;
using System.Collections;

public class cashScript : MonoBehaviour {
	
	
	public int cash = 0;
	
	// Use this for initialization
	void Start () {
	
	}
	
	
	
	public void addCash (int amount) {
		cash += amount;
		guiText.text = "Cash: " + cash + "€";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
