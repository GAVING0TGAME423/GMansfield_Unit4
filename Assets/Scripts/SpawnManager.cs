using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Enemyprefab;
    private float spawnrange = 8.5f;
    void Start()
    {
       
        Instantiate(Enemyprefab, GenerateSpawnPos(), Enemyprefab.transform.rotation);
    }

   Vector3 GenerateSpawnPos()
    {
        float xPos = Random.Range(-spawnrange, spawnrange);
        float zPos = Random.Range(-spawnrange, spawnrange);
        Vector3 spawnposition = new Vector3(xPos, Enemyprefab.transform.position.y, zPos);
        return spawnposition;
    }
   
}
