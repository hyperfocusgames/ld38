using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;

public class MusicManager : SingletonBehaviour<MusicManager> {

	public AudioClip mainMusic;
	public AudioMixer mixer;
	public float menuEffectTransitionTime = 0.5f;

	AudioSource source;

	AudioMixerSnapshot _menuEffectSnapshot;
	AudioMixerSnapshot menuEffectSnapshot {
		get {
			if (_menuEffectSnapshot == null) {
				_menuEffectSnapshot = mixer.FindSnapshot("Menu");
			}
			return _menuEffectSnapshot;
		}
	}

	bool _menuEffectEnabled;
	public bool menuEffectEnabled {
		get {
			return _menuEffectEnabled;
		}
		set {
			if (value != _menuEffectEnabled) {
				_menuEffectEnabled = value;
				menuEffectSnapshot.TransitionTo(menuEffectTransitionTime);
			}
		}
	}

	void Awake() {
		if (instance != this) {
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
		source = GetComponent<AudioSource>();
		source.clip = mainMusic;
	}

	public void SetCustomMusic(AudioClip music) {
		source.clip = music;
		source.Play();
	}

	public void ResetCustomMusic() {
		SetCustomMusic(mainMusic);
	}

}
