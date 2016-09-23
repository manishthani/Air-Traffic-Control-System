using UnityEngine;
using System.Collections;

public class DestroyNodes : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		Destroy (other.gameObject);
	}
}
