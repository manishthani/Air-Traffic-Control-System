using UnityEngine;
using System;

[Serializable]
public class SettingsModel {

	public int maxFutureDistance;
	public int shortRadius;
	public int longRadius;
	public int speed;

	public SettingsModel (int maxFutureDistance, int shortRadius, int longRadius, int speed) {
		this.maxFutureDistance = maxFutureDistance;
		this.shortRadius = shortRadius;
		this.longRadius = longRadius;
		this.speed = speed;
	} 
	public SettingsModel (){}
}