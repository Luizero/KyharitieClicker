using UnityEngine;
using System.Collections;

public class clickScript : MonoBehaviour {
	
	public GameObject chip;
	public GameObject chipSpawn;
	public float angle = 0f;
	public float days = 90f;
	public float hydroConstant = 0f;
	public GameObject chipSpawnPoint;
	public ParticleSystem hatsi;
	public Quaternion chipDefaultRotation;
	public Quaternion targetRotation;
	public Quaternion previousRotation;
	public weedScript weedScore;
	public cashScript cash;
	public float resetting = 0f;
	public kuumotusScript kuumotus;
	Vector3 size;
	Vector3 targetSize;
	// Use this for initialization
	void Start () {
		cash = GameObject.Find("GuiCash").GetComponent("cashScript") as cashScript;
		kuumotus = GameObject.Find("kuumotusmittari").GetComponent("kuumotusScript") as kuumotusScript;
		
		if (chip)
		{
			chipDefaultRotation = chip.transform.localRotation;
			targetRotation = chip.transform.localRotation;
			size = chip.transform.localScale;
			targetSize = size;

		}
	}
	
	void OnMouseDown() {
		if (chip  && resetting <= 0f) {
			chip.transform.RotateAround(Vector3.up, Mathf.PI/days);
			angle += Mathf.PI/days;
			targetRotation = chip.transform.localRotation;
			chip.transform.localScale *= 1.3f;
			
		}
		if (!chip && cash.cash >= 200) {
			chip = Instantiate(chipSpawn, chipSpawnPoint.transform.position, Quaternion.identity) as GameObject;
			chip.transform.RotateAround(Vector3.down, Mathf.PI*3f);
			chip.transform.RotateAround(Vector3.right, Mathf.PI/2f);
			chip.transform.RotateAround(Vector3.forward, Mathf.PI);
			chipDefaultRotation = chip.transform.localRotation;
			targetRotation = chip.transform.localRotation;
			cash.addCash (-200);
			size = chip.transform.localScale;
			targetSize = size;

		}

	}
	
	// Update is called once per frame
	void Update () {
		if (chip) {
			chip.transform.localRotation = Quaternion.Slerp(chip.transform.localRotation, targetRotation, Time.deltaTime * 6.0f); 
			chip.transform.localScale = Vector3.Slerp(chip.transform.localScale, size,Time.deltaTime*10f);
		}
		if (resetting>0f){
			resetting-=Time.deltaTime;	
		}
		
		if (Input.GetMouseButtonDown(0)) {
			if (chip && resetting <= 0f) {
				chip.transform.RotateAround(Vector3.up, (Mathf.PI/days) * hydroConstant);
				angle += (Mathf.PI/days) * hydroConstant;
				targetRotation = chip.transform.localRotation;
				if (hydroConstant > 0f) {
					chip.transform.localScale *= 1.3f;
				}
			}
		}
		
		// SCORE SUM POT
		if (angle>= Mathf.PI) {
			angle = 0f;
			//chip.transform.localRotation = chipDefaultRotation;
			Instantiate(hatsi, chip.transform.position + new Vector3(0,0,-1), Quaternion.Euler(-90,0,0));
			weedScore.addWeed(50);			
			targetRotation = chipDefaultRotation;
			kuumotus.addKuumotus(5f);
			resetting = 0.5f;
			

		}
	}
}
