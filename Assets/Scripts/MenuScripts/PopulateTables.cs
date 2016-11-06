﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopulateTables: MonoBehaviour {
	private float offset = 30.0f;
	private int rankIndex = 1;
	private int i = 0;

	public void addRowToTable (GameObject table, GameObject rowView, ArrayList rowData) {
		GameObject instance = Instantiate (rowView) as GameObject;
		instance.transform.SetParent (table.transform, false);

		instance.transform.Translate (new Vector3 (0.0f, -offset, 0.0f));

		Text[] texts = instance.GetComponentsInChildren<Text> ();

		// Populate the new instance with given username and score
		texts[0].text = rowData[0].ToString();
		texts[1].text = rowData[1].ToString();
		texts[2].text = rowData[2].ToString();

		offset += 30.0f;
		++rankIndex;
		++i;

	}
}
