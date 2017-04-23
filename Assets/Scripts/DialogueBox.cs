using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueBox : MonoBehaviour {
	public float letterSpeed;				//time between each letter in line
	public float lineSpeedPerLetter;		//pause time after letters are finished
	public Dialogue[] dialogue;

	private static GameObject panel;
	private static TextMeshProUGUI m_TextComponent;
	private static DialogueBox instance;
	private bool hasTextChanged;

	public bool playOnAwake = true;

	void Awake(){
		panel = transform.GetChild (0).gameObject;
		m_TextComponent = GetComponentInChildren <TextMeshProUGUI> ();
		instance = GetComponent<DialogueBox> ();
		panel.SetActive (false);
		if (playOnAwake) {
			DialogueBox.Play(m_TextComponent, dialogue);
		}
	}

	public static void Play(TMP_Text textComponent, Dialogue[] dialogue) {
		panel.SetActive(true);
		instance.StartCoroutine(instance.RevealCharacters(textComponent, dialogue));
	}

	/// <summary>
	/// Method revealing the text one character at a time.
	/// </summary>
	/// <returns></returns>
	IEnumerator RevealCharacters(TMP_Text textComponent, Dialogue[] dialogue) {
		textComponent.ForceMeshUpdate();
		int line = 0;

		TMP_TextInfo textInfo = textComponent.textInfo;
		textComponent.text = dialogue[line].name + ": " + dialogue[line].dialogue;

		int totalVisibleCharacters = textInfo.characterCount; // Get # of Visible Character in text object
		int visibleCount = 0;

		while (line < dialogue.Length) {
			if (hasTextChanged) {
				totalVisibleCharacters = textInfo.characterCount; // Update visible character count.
				hasTextChanged = false;
			}

			if (visibleCount > totalVisibleCharacters) {
				yield return new WaitForSeconds(lineSpeedPerLetter);
				visibleCount = 0;
				line++;
				if (line < dialogue.Length) {
					textComponent.text = dialogue[line].name + ": " + dialogue[line].dialogue;
				}else {
					panel.SetActive(false);
				}
			}

			textComponent.maxVisibleCharacters = visibleCount; // How many characters should TextMeshPro display?

			visibleCount += 1;

			yield return new WaitForSeconds(letterSpeed);
		}
	}


	/// <summary>
	/// Method revealing the text one word at a time.
	/// </summary>
	/// <returns></returns>
	IEnumerator RevealWords(TMP_Text textComponent) {
		textComponent.ForceMeshUpdate();

		int totalWordCount = textComponent.textInfo.wordCount;
		int totalVisibleCharacters = textComponent.textInfo.characterCount; // Get # of Visible Character in text object
		int counter = 0;
		int currentWord = 0;
		int visibleCount = 0;

		while (true) {
			currentWord = counter % (totalWordCount + 1);

			// Get last character index for the current word.
			if (currentWord == 0) // Display no words.
				visibleCount = 0;
			else if (currentWord < totalWordCount) // Display all other words with the exception of the last one.
				visibleCount = textComponent.textInfo.wordInfo[currentWord - 1].lastCharacterIndex + 1;
			else if (currentWord == totalWordCount) // Display last word and all remaining characters.
				visibleCount = totalVisibleCharacters;

			textComponent.maxVisibleCharacters = visibleCount; // How many characters should TextMeshPro display?

			// Once the last character has been revealed, wait 1.0 second and start over.
			if (visibleCount >= totalVisibleCharacters) {
				yield return new WaitForSeconds(1.0f);
			}

			counter += 1;

			yield return new WaitForSeconds(0.1f);
		}
	}

	// Event received when the text object has changed.
	void ON_TEXT_CHANGED(Object obj) {
		hasTextChanged = true;
	}

	//IEnumerator PrintText(string message) {
	//	text.text = "";
	//	panel.SetActive(true);
	//	string name = "<i>";
	//	char[] fileChars = message.ToCharArray();
	//	int count = -1;
	//	foreach (char fileChar in fileChars) {
	//		if (count < 0) {
	//			if (fileChar == '\n' || fileChar == '\n') {
	//				name += ":</i> ";
	//				text.text = name;
	//				count = 0;
	//			} else
	//				name += fileChar;
	//		} else if (fileChar == '\n' || fileChar == '\n') {
	//			yield return new WaitForSeconds(lineSpeedPerLetter * count);
	//			text.text = name;
	//			count = 0;
	//		} else {
	//			text.text += fileChar;
	//			yield return new WaitForSeconds(letterSpeed);
	//			count++;
	//		}
	//	}
	//	yield return new WaitForSeconds(lineSpeedPerLetter * count);
	//	panel.SetActive(false);
	//	text.text = "";
	//}

	[System.Serializable]
	public class Dialogue {
		public string name = "";
		[TextArea(3, 10)]
		public string dialogue = "";
	}
}



//namespace TMPro.Examples {
//	public class TextConsoleSimulator : MonoBehaviour {
//		private TMP_Text m_TextComponent;


//		void Start() {
			
//		}


//		void OnEnable() {
//			// Subscribe to event fired when text object has been regenerated.
//			TMPro_EventManager.TEXT_CHANGED_EVENT.Add(ON_TEXT_CHANGED);
//		}

//		void OnDisable() {
//			TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(ON_TEXT_CHANGED);
//		}


//		// Event received when the text object has changed.
//		void ON_TEXT_CHANGED(Object obj) {
//			hasTextChanged = true;
//		}


		

//	}
//}