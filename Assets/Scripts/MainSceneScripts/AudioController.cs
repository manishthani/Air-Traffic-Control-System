using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {
	public static AudioController AudioCtrl;

	private AudioSource sourceShortConflictAlarm;

	// Use this for initialization
	void Start () {
		if (AudioCtrl == null) {
			AudioCtrl = GameObject.FindGameObjectWithTag ("AudioCtrl").GetComponent<AudioController> ();
		}
		sourceShortConflictAlarm = GetComponent<AudioSource> ();

	}
	
	public void PlayAudioSource(){
		sourceShortConflictAlarm.Play ();
	}

	public void StopAudioSource(){
		sourceShortConflictAlarm.Stop ();
	}
}


