using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomPropertyDrawer(typeof(UpgradeAssetShipStatModifier))]
public class UpgradeAssetShipStatModifierDrawer : PropertyDrawer {

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
		var indent = EditorGUI.indentLevel;
		EditorGUI.indentLevel = 0;
		EditorGUI.BeginProperty(position, label, property);
		float lineHeight = EditorGUIUtility.singleLineHeight;
		Rect checkPosition = position;
		checkPosition.width = lineHeight;
		position.width -= lineHeight;
		position.x += lineHeight;
		SerializedProperty activeProperty = property.FindPropertyRelative("active");
		EditorGUI.PropertyField(checkPosition, activeProperty, GUIContent.none);
		bool enabled = !activeProperty.hasMultipleDifferentValues && activeProperty.boolValue;
		position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
		if (enabled) {
			EditorGUI.PropertyField(position, property.FindPropertyRelative("increment"), GUIContent.none);
		}
		EditorGUI.EndProperty();
		EditorGUI.indentLevel = indent;
	}

}
