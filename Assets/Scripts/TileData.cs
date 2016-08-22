using UnityEngine;
using System.Collections;

public class TileData : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		// Create ray with direction
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit2D[] hits;
		hits = Physics2D.RaycastAll(ray.origin, ray.direction, Mathf.Infinity);

		// Go through all hit objects and output tile coordinate and 
		// object name
		for (int i = 0; i < hits.Length; i++) {
			RaycastHit2D hit = hits [i];
			float x = Mathf.FloorToInt((hit.point.x) * 10);
			float y = Mathf.FloorToInt((hit.point.y) * 10);
			string n = hit.collider.transform.parent.name;
			Debug.Log ("Tile: " + x + ", " + y + ", " + n);
		}
	}
}
