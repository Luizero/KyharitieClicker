using UnityEngine;
using System.Collections;

public class weedScript : MonoBehaviour {
	
	public int weed = 0;
	
	// Use this for initialization
	void Start () {
	
	}

	public void addWeed (int weedAdd) {
		weed += weedAdd;
		guiText.text = "Weed: " + weed + "g";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
