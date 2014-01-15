using UnityEngine;
using System.Collections;

public class luuriScript : MonoBehaviour {
	
	public Vector3 sijainti;
	public float stillRingsFor = 2f;
	public float ringing = 2f;
	public int saleAmount = 1;
	
	public cashScript cash;
	public weedScript weed;
	
	
	// Use this for initialization
	void Start () {
		cash = GameObject.Find("GuiCash").GetComponent("cashScript") as cashScript;
		weed = GameObject.Find("GuiWeed").GetComponent("weedScript") as weedScript;
		sijainti = transform.position;
		StartCoroutine("call");
	}
	
	IEnumerator call () {
		while (true) {
			yield return new WaitForSeconds (5f);
			if (weed.weed > saleAmount && stillRingsFor <= 0f) {
				if (Random.Range(0f,100f) > 80f) {
					puhelu();
				}
			}
		}
	}
	
	public void puhelu () {
		stillRingsFor = Random.Range(10f, 30f);
		ringing = 1f;
	}
	
	void OnMouseDown() {
		if (weed.weed >= saleAmount)
		{
			weed.addWeed(-saleAmount);
			cash.addCash ( saleAmount * 15);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (stillRingsFor > 0f) {
			stillRingsFor -= Time.deltaTime;
			if (ringing > -1f) {
				ringing -= Time.deltaTime;	
			}
			if (ringing <= -1f) {
				ringing = 1f;	
			}
			
			if (ringing > 0f ){
				transform.position = sijainti + new Vector3(Random.Range(-0.1f,0.1f),Random.Range(-0.1f,0.1f),sijainti.z);
			}
		}
	}
}
