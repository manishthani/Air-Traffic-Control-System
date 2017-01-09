using UnityEngine;
using System.Collections;
using NUnit.Framework;

public class TestInputValidation {


	private bool isAirplaneWaypointsInputEmpty (string x, string y, string z) {
		if (x == string.Empty|| y == string.Empty || z == string.Empty) {
			return true;
		}
		return false;
	}

	private bool isAirplaneWaypointsOutOfRange (float x, float y, float z) {
		if ((x < 0 || x > 200.0f ) || (y < 0 || y > 200.0f)|| (z < 1000 || z > 25000)) {
			return true;
		}
		return false;
	}


	private bool isAirplaneModelNameInputEmpty (string name) {
		if (name == string.Empty) {
			return true;
		}
		return false;
	}

	[Test]
	public void AssertValidationInput() {
		Assert.That (isAirplaneModelNameInputEmpty("") == true);
		Assert.That (isAirplaneModelNameInputEmpty("HELLO") == false);

		Assert.That (isAirplaneWaypointsInputEmpty("", "", "") == true);
		Assert.That (isAirplaneWaypointsInputEmpty("3.4", "4.3", "11.2") == false);

		Assert.That (isAirplaneWaypointsOutOfRange(100.0f, 100.0f, 100.0f) == true);
		Assert.That (isAirplaneWaypointsOutOfRange(100.0f, 100.0f, 1000.0f) == false);

	}

}
