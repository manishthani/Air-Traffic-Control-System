using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopulateTables: MonoBehaviour {
	private float offset = 40.0f;
	private ArrayList rows;

	public PopulateTables() {
		rows = new ArrayList ();
	}

	public void addRowToTable (GameObject table, GameObject rowView, ArrayList rowData) {
		GameObject instance = Instantiate (rowView) as GameObject;
		instance.transform.Translate (new Vector3 (0.0f, -offset, 0.0f));
		instance.transform.SetParent (table.transform, false);



		rows.Add (instance);

		Text[] texts = instance.GetComponentsInChildren<Text> ();

		// Populate the new instance with given username and score
		texts[0].text = rowData[0].ToString();
		texts[1].text = rowData[1].ToString();
		texts[2].text = rowData[2].ToString();

		// Get height of rowView
		offset += ((rowView.GetComponent<RectTransform> ().rect.yMax - rowView.GetComponent<RectTransform> ().rect.yMin)* rowView.transform.localScale.y);
	}

	public void removeRows(GameObject table) {
		for (int i = 0; i < table.transform.childCount; ++i) {
			// Only removes instances, not prefab
			if (table.transform.GetChild(i).name.Contains ("(Clone)")) {
				Destroy (table.transform.GetChild (i).gameObject);
			}
		}
		rows.Clear ();
		offset = 40.0f;
	} 
}
