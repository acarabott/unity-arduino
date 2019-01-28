using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour {
  public SerialHandler handler;

	void Update () {
		if (!handler) { return; }

		float scale = handler.data.A0 * 5.0f;
		gameObject.transform.localScale = new Vector3(scale, scale, scale);

		Renderer sphereRenderer = gameObject.GetComponent<Renderer>();
		if (sphereRenderer && sphereRenderer.material) {
				sphereRenderer.material.color = handler.data.D2 == 1
						? Color.white
						: Color.black;
		}
	}
}
