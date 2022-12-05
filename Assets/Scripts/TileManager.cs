using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tiles;
    public GameObject terrain;
    public float tileSpawnPos = 0;
    public Vector3 terrainSpawnPos = new Vector3(0.7623999f, 16.05456f, 77.7f);
    public float tileLength = 70;
    public float terrainLength = 140;
    public int tileQuantity = 10;
    public int terrainQuantity = 5;
    private List<GameObject> activeTiles = new List<GameObject>();
    private List<GameObject> activeTerrain = new List<GameObject>();
    public Transform playerTransform;
    public float offset = 50;
    void Start()
    {
        SpawnTile(0);
        for(int i = 0; i<tileQuantity; i++){
            SpawnTile(Random.Range(0, tiles.Length));
        }
        for(int i = 0; i<terrainQuantity; i++){
            SpawnTerrain();
        }
    }

    void Update()
    {
        if(playerTransform.position.z - offset >= tileSpawnPos - (tileQuantity * tileLength)){
            SpawnTile(Random.Range(0, tiles.Length));
            Destroy(activeTiles[0]);
            activeTiles.RemoveAt(0);
        }
        if(playerTransform.position.z - offset >= terrainSpawnPos.z - (terrainQuantity * terrainLength)){
            SpawnTerrain();
            Destroy(activeTerrain[0]);
            activeTerrain.RemoveAt(0);
        }
    }
    public void SpawnTile(int tileIndex){
        GameObject newTile = Instantiate(tiles[tileIndex], transform.forward * tileSpawnPos, transform.rotation);
        activeTiles.Add(newTile);
        tileSpawnPos += tileLength;
    }
    public void SpawnTerrain(){
        GameObject newTerrain = Instantiate(terrain, terrainSpawnPos, transform.rotation);
        activeTerrain.Add(newTerrain);
        terrainSpawnPos.z += terrainLength;
    }
}
