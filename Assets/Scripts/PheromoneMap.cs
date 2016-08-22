using UnityEngine;
using System.Collections;

public class PheromoneMap : MonoBehaviour {
// This class stores a table of pheromone data

	Tiled2Unity.TiledMap tiledMap;
	public float[,] pheromoneTable;
	public int numTilesHigh;
	public int numTilesWide;
	public float tileWidth;

	// Use this for initialization
	void Awake () {
		tiledMap = GetComponent<Tiled2Unity.TiledMap> ();
		numTilesHigh = tiledMap.NumTilesHigh;
		numTilesWide = tiledMap.NumTilesWide;
		tileWidth = tiledMap.TileWidth;
		pheromoneTable = new float[numTilesHigh, numTilesWide];
		for (int i = 0; i < numTilesHigh; i++) {
			for (int j = 0; j < numTilesWide; j++) {
				pheromoneTable [i, j] = 0;
			}
		}
	}

//	public float getPheromone (int row, int col) {
//		return pheromoneTable [row, col];
//	}
//
//	public void addPheromone (int row, int col, float phero) {
//		pheromoneTable [row, col] += phero;
//	}
//
//	public void setPheromone (int row, int col, float phero) {
//		pheromoneTable [row, col] = phero;
//	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
