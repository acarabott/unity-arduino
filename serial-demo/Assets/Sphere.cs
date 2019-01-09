using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour {
   public SerialReader reader;

	void Update () {
		if (!reader) { return; }

		float scale = reader.data.potValue * 5.0f;
		gameObject.transform.localScale = new Vector3(scale, scale, scale);

		Renderer sphereRenderer = gameObject.GetComponent<Renderer>();
		if (sphereRenderer && sphereRenderer.material) {
				sphereRenderer.material.color = reader.data.isButtonDown
						? Color.white
						: Color.black;
		}
	}
}
