using UnityEngine;
using System.Collections;

public class CPUAirplaneMovement : MonoBehaviour {

	public int speed = 2;

	// Use this for initialization 
	void Start () {
		int randomNumber = Random.Range (1, 20);
		this.transform.Translate ((float)randomNumber, 0.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
		//this.transform.Translate (speed/2 * Time.deltaTime * Vector3.back);

	}
}
