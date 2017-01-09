using UnityEngine;
using System.Collections;
using NUnit.Framework;

public class TestAirplaneData  {

	private static string PATH_TEST = "/airplanes_test.dat";

	// Test 1: Data insertion
	[Test]
	public void AssertAirplaneSaved() {

		AirplaneStorage storage = new AirplaneStorage (PATH_TEST);

		// Create Airplane Model
		ArrayList waypoints = new ArrayList ();
		waypoints.Add (new Vector3 (0.0f, 0.0f, 1000.0f));
		waypoints.Add (new Vector3 (100.0f,100.0f,1000.0f));

		AirplaneModel airplaneModel = new AirplaneModel (1, "test", Utilities.parseToString (waypoints));

		// Save the model in file
		storage.Save (airplaneModel);

		// Load the airplane
		ArrayList result = storage.Load ();
		// Assert that the number of airplanes model is 1
		Debug.Log (result.Count);


		// Assert AirplaneModel attributes with the first AirplaneModel in file
		AirplaneModel resultModel = (AirplaneModel)result [0];

		Assert.That (resultModel.id == airplaneModel.id);
		Assert.That (resultModel.name == airplaneModel.name);
		Assert.That (resultModel.waypoints == airplaneModel.waypoints);

	}

	// Test 2: Data insertion
	[Test]
	public void AssertAirplaneInserted() {

		AirplaneStorage storage = new AirplaneStorage (PATH_TEST);

		// Create Airplane Model
		ArrayList waypoints = new ArrayList ();
		waypoints.Add (new Vector3 (0.0f, 0.0f, 1000.0f));
		waypoints.Add (new Vector3 (100.0f,100.0f,1000.0f));

		AirplaneModel airplaneModel = new AirplaneModel (1, "test", Utilities.parseToString (waypoints));

		// Save the model in file
		storage.Save (airplaneModel);

		// Update Airplane Model
		string name = "updatedTest";
		waypoints [0] = new Vector3 (50.0f, 50.0f, 1000.0f);
		airplaneModel = new AirplaneModel (1, name , Utilities.parseToString (waypoints));

		// Update it in File
		storage.Insert (airplaneModel);


		// Load the airplane
		ArrayList result = storage.Load ();

		// Assert AirplaneModel attributes with the first AirplaneModel in file
		AirplaneModel resultModel = (AirplaneModel)result [0];

		Assert.That (resultModel.id == airplaneModel.id);
		Assert.That (resultModel.name == airplaneModel.name);
		Assert.That (resultModel.waypoints == airplaneModel.waypoints);

	}

	// Test 3: Data deletion
	[Test]
	public void AssertAirplaneDelete() {

		AirplaneStorage storage = new AirplaneStorage (PATH_TEST);

		// Update it in File
		storage.deleteAirplaneWithId (1);

		// Load the airplane
		ArrayList result = storage.Load ();

		bool found = false;
		foreach (AirplaneModel model in result) {
			if (model.id == 1) {
				found = true;
			}
		}
		Assert.That (found == false);
	}

	// Test4: Complex test
	[Test]
	public void AssertComplexQueries() {
		AirplaneStorage storage = new AirplaneStorage (PATH_TEST);

		// Create Airplane Model
		ArrayList waypoints = new ArrayList ();
		waypoints.Add (new Vector3 (0.0f, 0.0f, 1000.0f));
		waypoints.Add (new Vector3 (100.0f,100.0f,1000.0f));

		AirplaneModel airplaneModel = new AirplaneModel (1, "test", Utilities.parseToString (waypoints));

		// Save the model in file
		storage.Save (airplaneModel);

		// Load the airplane
		ArrayList result = storage.Load ();
		// Assert that the number of airplanes model is 1
		Debug.Log (result.Count);


		// Assert AirplaneModel attributes with the first AirplaneModel in file
		AirplaneModel resultModel = (AirplaneModel)result [0];

		Assert.That (resultModel.id == airplaneModel.id);
		Assert.That (resultModel.name == airplaneModel.name);
		Assert.That (resultModel.waypoints == airplaneModel.waypoints);




	}
}
