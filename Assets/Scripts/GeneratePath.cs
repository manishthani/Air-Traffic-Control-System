using UnityEngine;
using System.Collections;

public class GeneratePath : MonoBehaviour {

	public GameObject origin;
	public GameObject sampleNode;
	public GameObject destination;

	private Vector3 positionOrigin;
	private Vector3 positionDestination;

	private Queue nextBatchNodes;
	private int totalNodes = 40;
	private int indexCurrent = 1;
	private int batch = 10;

	public float speed = 1.0f;

	public void computeNextNodes (int indexFinal, int totalNodes ) {
		while (indexCurrent < indexFinal) { 
			Vector3 position = Vector3.Lerp (positionOrigin, positionDestination, (float)indexCurrent / totalNodes);
			nextBatchNodes.Enqueue(position);
			Instantiate (sampleNode, position, origin.transform.rotation) ;
			++indexCurrent;
		}
	}

	// Use this for initialization
	void Start () {
		nextBatchNodes = new Queue ();
		positionOrigin = origin.transform.position;
		positionDestination = destination.transform.position;
		int indexFinal = indexCurrent + batch;
		if (indexFinal <= totalNodes) {
			computeNextNodes (indexFinal, totalNodes);
		}

	}

	// Update is called once per frame
	void Update () {
		Vector3 lastPosition = (Vector3)nextBatchNodes.Peek ();
		origin.transform.position = Vector3.MoveTowards (origin.transform.position, lastPosition, speed * Time.deltaTime);
		if (origin.transform.position == lastPosition) {
			nextBatchNodes.Dequeue ();
			computeNextNodes (indexCurrent + 1, totalNodes);
		}

	}
}
