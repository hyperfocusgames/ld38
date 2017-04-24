using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

	SurfaceEntity entity;

	private bool paused = false;
	private float minPauseTime = 1f;
	private float lastPauseTime = float.MinValue;
	public GameObject pauseWindow;

	void Awake() {
		entity = GetComponent<SurfaceEntity>();
	}
	
	void Start() {
		entity.body.velocity = transform.forward; // give it a tiny push to fix the camera shit (this is a game jam ok)
	}

	void Update() {
		if(Input.GetButtonDown("Pause"))
		{
			if(Time.time - lastPauseTime > minPauseTime)
			{
				if(paused)
				{
					Destroy(GameObject.FindGameObjectWithTag("PauseWindow"));
					Time.timeScale = 1;
				}
				else
				{
					Instantiate(pauseWindow, Vector3.zero, Quaternion.identity);
					Time.timeScale = 0;
				}
				paused = !paused;
			}
		}
	}

	void FixedUpdate() {
		Vector3 up = CameraRig.instance.transform.up;
		Vector3 right = CameraRig.instance.transform.right;
		Vector3 input
			= up * Input.GetAxisRaw("Vertical")
			+ right * Input.GetAxisRaw("Horizontal");
		input.Normalize();
		entity.body.AddForce(input * PlayerData.player.moveSpeed);
		
		if(Input.GetAxisRaw("Fire1") > 0)
		{
			PlayerData.player.shoot();
		}
	}

}
