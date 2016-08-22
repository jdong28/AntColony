using UnityEngine;
using System.Collections;

public class AntController : MonoBehaviour {

	public GameObject antMap;
	Rigidbody2D rb2d;
	// Velocity vector
	// Note rb2d.velocity is not used because it uses force
	Vector2 DirectionVector;
	public float speed = 0.005f;
	private float tChange = 0f;
	PheromoneMap pheromoneMap; 
	int pheroRow;
	int pheroCol;
	int tilesWide;
	int tilesHigh;
	float tileWid;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		// DirectionVector = Vector2.up;
		pheromoneMap = antMap.GetComponent<PheromoneMap> ();
		tilesWide = pheromoneMap.numTilesWide;
		tilesHigh = pheromoneMap.numTilesHigh;
		tileWid = pheromoneMap.tileWidth;
	}

	// Update is called once per frame
	void Update () {
		// Determine current position in pheromone table
		pheroRow = Mathf.FloorToInt(rb2d.position.y / (tileWid / 100));
		pheroCol = Mathf.FloorToInt(rb2d.position.x / (tileWid / 100));
		Debug.Log ("At row " + pheroRow + ", column " + pheroCol);

		// WIP, add previous row/col variables so only update pheromone value on new tile
	}
	void OnCollisionEnter2D(Collision2D coll) {
		// Flip direction on collision
		DirectionVector = DirectionVector * -1;
    }
	void OnCollisionExit2D(Collision2D coll) {
		// Necessary to activate collision again
        // rb2d.isKinematic = false;
    }
	// Change direction peridodically randomly
	void FixedUpdate () {
		if (Time.time >= tChange) {
			RandomDirection ();
			tChange = tChange + Random.Range (1.0f, 2.5f);
		}
		MoveWithRotate();
	}
	// Generate a random direction
	void RandomDirection () {
		int caseSwitch = Random.Range(1, 5);
		switch (caseSwitch) {
		case 1:
			DirectionVector = Vector2.up;
			break;
		case 2:
			DirectionVector = Vector2.down;
			break;
		case 3:
			DirectionVector = Vector2.left;
			break;
		case 4:
			DirectionVector = Vector2.right;
			break;
		}
	}
	// Moves and rotates object according to movement vector
	void MoveWithRotate () {
		if (DirectionVector != Vector2.zero) {
			// Move then rotate
			rb2d.MovePosition(rb2d.position + DirectionVector * speed);
			float angle = Mathf.Atan2(DirectionVector.y, DirectionVector.x) * Mathf.Rad2Deg+180;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		} 		
	}
}
