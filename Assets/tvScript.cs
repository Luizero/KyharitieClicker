using UnityEngine;
using System.Collections;

public class tvScript : MonoBehaviour {
	
	public float targetIntensity = 1f;
	float changeIntensity = 0f;
	float changeSpeed = 1f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (changeIntensity > 0f) {
			changeIntensity -= Time.deltaTime;	
		}
		if (changeIntensity <= 0f) {
			targetIntensity = Random.Range(0f,2f);	
			changeIntensity = Random.Range(0.1f,1f);
			changeSpeed = Random.Range(0.5f,5f);
		}
		light.intensity = Mathf.Lerp(light.intensity, targetIntensity, Time.deltaTime*changeSpeed);
	}
}
