using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//hello son
public class SpawnTiles : MonoBehaviour {

    private int amtTilesOnScreen = 5; //how many tiles to create
    public GameObject[] TilePrefabs; //no of idfferent prefabs
    public static  Transform playerTransform; //current player position
    private float tileLength = 22.0f; //lenght of each prefab tile
    private float spawnZ = -3.0f; //where to spawn object
    private float safeZone = 25.0f;
    private int lastPrefabIndex = 0;

    private List<GameObject> activeTiles;

	// Use this for initialization
	void Start () {
        activeTiles = new List<GameObject>();

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
  
        for (int i =0; i < amtTilesOnScreen; i++)
        {
            spawnTile();
         
        }
    }
	
	// Update is called once per frame
	void Update () {
		if (playerTransform.position.z - safeZone  > (spawnZ-amtTilesOnScreen * tileLength))
        {
            spawnTile();
            DeleteTile();
        }
	}

    private void spawnTile(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(TilePrefabs[RandomPrefabIndex()]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
    }

    private void DeleteTile()
    {
       Destroy(activeTiles[0]);
       activeTiles.RemoveAt(0); 
    }

    private int RandomPrefabIndex()
    { 
        if (TilePrefabs.Length <=1)
        {
            return 0;
            
        }
        int randIndex = lastPrefabIndex;
        while (randIndex == lastPrefabIndex)
        {
            randIndex = Random.Range(0, TilePrefabs.Length);
        }

        lastPrefabIndex = randIndex;
        return randIndex;
    }

    

    }
