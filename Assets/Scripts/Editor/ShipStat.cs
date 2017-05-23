using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomPropertyDrawer(typeof(ShipStat))]
public class ShipStatDrawer : PropertyDrawer {

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
		EditorGUI.BeginProperty(position, label, property);
		EditorGUI.PropertyField(position, property.FindPropertyRelative("baseValue"), label);
		EditorGUI.EndProperty();
	}

}

