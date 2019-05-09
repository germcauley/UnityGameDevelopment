using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour {

	public float scrollSpeed = 0.1f;

	private MeshRenderer mesh_renderer;


	// Use this for initialization
	void Awake () {
		mesh_renderer = GetComponent<MeshRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		float x = Time.time * scrollSpeed;

		Vector2 offset = new Vector2 (x, 0);

		mesh_renderer.sharedMaterial.SetTextureOffset ("_MainTex",offset);
	}
}
