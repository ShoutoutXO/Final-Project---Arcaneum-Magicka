using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] Food_Bone_01Prefabs;

    private float spawnLimitXLeft = 25;
    private float spawnLimitXRight = -8;
    private float spawnPosY = 0;

    private float startDelay = 0.0f;
    private float spawnInterval = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnRandomFood_Bone_01();
    }

    // Spawn rain at random x position at top of play area
    void SpawnRandomFood_Bone_01()
    {
        // Generate random rain index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate rain at random spawn location
        int Food_Bone_01Number = Random.Range(0, Food_Bone_01Prefabs.Length);
        Instantiate(Food_Bone_01Prefabs[Food_Bone_01Number], spawnPos, Food_Bone_01Prefabs[Food_Bone_01Number].transform.rotation);
        Invoke("SpawnRandomFood_Bone_01", Random.Range(2f, 4f));
    }

}
