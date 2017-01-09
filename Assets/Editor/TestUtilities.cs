using UnityEngine;
using System.Collections;
using NUnit.Framework;

public class TestUtilities{

	[Test]
	public void AssertParseToVector() {
		string waypoints = "100.0,100.0,0.0;2000.0,300.0,399.0";
		ArrayList waypointsArray = Utilities.parseToVector3(waypoints);

		Assert.That (waypointsArray.Count == 2);

		Vector3 waypoint0 = (Vector3) waypointsArray [0];
		Assert.That (waypoint0.x == 100.0f);
		Assert.That (waypoint0.y == 100.0f);
		Assert.That (waypoint0.z == 0.0f);

		Vector3 waypoint1 = (Vector3) waypointsArray [1];
		Assert.That (waypoint1.x == 2000.0f);
		Assert.That (waypoint1.y == 300.0f);
		Assert.That (waypoint1.z == 399.0f);

	}


	[Test]
	public void AssertParseToString() {
		ArrayList array = new ArrayList ();
		array.Add (new Vector3 (0.5f, 0.5f, 0.5f));
		array.Add (new Vector3(100.5f,100.5f,100.5f));

		Assert.That (array.Count == 2);

		string waypointsString = Utilities.parseToString (array);
		Debug.Log (waypointsString);
		Assert.That (waypointsString == "0.5,0.5,0.5;100.5,100.5,100.5");

	}
}
