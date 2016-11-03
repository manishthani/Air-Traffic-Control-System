using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {
	public static AudioController audioCtrl;

	private AudioSource sourceShortConflictAlarm;

	// Use this for initialization
	void Start () {
		if (audioCtrl == null) {
			audioCtrl = GameObject.FindGameObjectWithTag ("AudioCtrl").GetComponent<AudioController> ();
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


