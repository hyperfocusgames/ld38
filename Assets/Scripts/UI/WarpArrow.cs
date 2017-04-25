using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WarpArrow : MonoBehaviour {

	public float spinSpeed = 30;
	public Transform model;

	void Update() {
		Planet planet = LevelManager.instance.planet;
		Transform player = PlayerData.player.transform;
		Transform warpGate = planet.warpGate.transform;
		transform.position = player.position;
		Vector3 up = (player.position - planet.transform.position);
		Vector3 direction = (warpGate.position - planet.transform.position) - (player.position - planet.transform.position);
		direction = Vector3.ProjectOnPlane(direction, up);
		transform.LookAt(transform.position + direction, up);
		model.gameObject.SetActive(PlayerData.player.isAlive);
		Vector3 euler = model.localEulerAngles;
		euler.z = Time.time * spinSpeed;
		model.localEulerAngles = euler;
	}

}
