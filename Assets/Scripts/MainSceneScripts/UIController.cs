using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour{
	public static UIController UICtrl;

	private Text collisionScrollViewText;
	private GameObject warningPanel;
	private GameObject speedSlider;
	private GameObject airplaneMiniatureImage;
	private GameObject airplaneIcon;

	private Hashtable airplanesHash;
	// Use this for initialization
	void Start () {
		if (UICtrl == null) {
			UICtrl = GameObject.FindGameObjectWithTag ("UICtrl").GetComponent<UIController> ();
		}

		// This should not be in the controller!
		collisionScrollViewText = transform.FindChild ("CollisionInfoScrollView").FindChild ("ViewPort").FindChild ("Content").GetComponent<Text>();

			
		warningPanel = transform.FindChild ("WarningPanel").gameObject;
		speedSlider = transform.FindChild ("SpeedSlider").gameObject;
		airplaneMiniatureImage = transform.FindChild ("AirplaneMiniatureImage").gameObject;
		airplaneIcon = Resources.Load ("AirplaneIcon") as GameObject;

		airplanesHash = new Hashtable ();
		hideWarningPanel ();

	}

	public void addCollisionInfo (string description) {
		collisionScrollViewText.text += description + "\n\n";
	}

	public void showWarningPanel() {
		warningPanel.SetActive (true);
	}

	public void hideWarningPanel() {
		warningPanel.SetActive (false);
	}
		
	public void addWarningPanelInfo(string description) {
		warningPanel.transform.FindChild ("TextDescription").GetComponent<Text> ().text = description;
	}

	public void confirmExitButtonEvent() {
		GameMaster.gm.loadResultScene ();
	}

	public float getSpeedSliderValue() {
		return speedSlider.GetComponent<Slider> ().value;
	}

	public void updateAirplaneInMiniatureImage (string id, Vector3 position) {
		Vector2 normalizedVector = new Vector2 (((position.x/500.0f) * 150.0f), ((position.z/500.0f) * 150.0f));
		GameObject airplaneInstance = airplanesHash [id] as GameObject;

		airplaneInstance.transform.localPosition = new Vector3 (normalizedVector.x, normalizedVector.y, 0.0f);
	}

	public void addAirplaneInMiniatureImage (string id, Vector3 position) {

		Vector2 normalizedVector = new Vector2 (((position.x/500.0f) * 150.0f), ((position.z/500.0f) * 150.0f));
		GameObject airplaneInstance = Instantiate (airplaneIcon, new Vector3 (0.0f, 0.0f, 0.0f), airplaneMiniatureImage.transform.rotation) as GameObject;
		airplaneInstance.transform.parent = airplaneMiniatureImage.transform;
		airplaneInstance.transform.localPosition = new Vector3 (normalizedVector.x, normalizedVector.y, 0.0f);

		airplaneInstance.SetActive (true);

		airplanesHash.Add (id, airplaneInstance);
	}

}