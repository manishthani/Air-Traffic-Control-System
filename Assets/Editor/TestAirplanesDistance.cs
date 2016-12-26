using UnityEngine;
using System;
using NUnit.Framework;

public class TestAirplanesDistance {


	[Test]
	public void AssertDistanceAirplanes() {
		GameObject a1 = new GameObject ();
		GameObject a2 = new GameObject ();

		a1.transform.position = new Vector3 (0.0f,0.0f,500.0f);
		a2.transform.position = new Vector3 (0.0f,0.0f,200.0f);

		Assert.That (Vector3.Distance (a1.transform.position, a2.transform.position) == 300.0f);


	}

}
