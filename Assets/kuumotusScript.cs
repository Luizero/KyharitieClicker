using UnityEngine;
using System.Collections;

public class kuumotusScript : MonoBehaviour {
	
	public float kuumotus = 0f;
	public float maxKuumotus = 100f;
	public float yScaleStart = 0.151f;
	public float yScaleMax = 1.91f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	public void addKuumotus (float kuumotukset) {
		kuumotus += kuumotukset;
		transform.localScale = new Vector3(1f,Mathf.Clamp(yScaleStart + (yScaleMax-yScaleStart)/maxKuumotus * kuumotus,yScaleStart,yScaleMax),1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
