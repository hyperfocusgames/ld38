using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OcclusionCullingTrigger : MonoBehaviour {

    public float radius = 20;
    Renderer[] renderers;
    private float scale = 1;

    void Start() {
        Refresh();
    }

	void LateUpdate() {
        for (int i = 0; i < renderers.Length; i++) {
            if (renderers[i]) {
                renderers[i].enabled = Vector3.Distance(renderers[i].transform.position, transform.position) > radius * scale;
            }
        }
    }

    public void Refresh() {
        renderers = FindObjectsOfType(typeof(Renderer)) as Renderer[];
        if (transform.parent) {
            scale = transform.parent.localScale.z;
        }
        //Debug.Log(renderers.Length);
    }
}
