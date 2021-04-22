using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Enemyprefab;
    private float spawnrange = 8.5f;
    private int enemycount;
    private int wavenumber = 1;
    public GameObject powerupprefab;

    void Start()
    {
        spawnwave(wavenumber);
        
    }

    private void Update()
    {
        enemycount = FindObjectsOfType<Enemy>().Length;
        if (enemycount == 0)
        {
            wavenumber++;
            spawnwave(wavenumber);
        }
    }
    void spawnwave(int enemynum)
    {
        Instantiate(powerupprefab, GenerateSpawnPos(), powerupprefab.transform.rotation);
        for (int i = 0; i < enemynum; i++)
        {
            Instantiate(Enemyprefab, GenerateSpawnPos(), Enemyprefab.transform.rotation);
        }
    }

   Vector3 GenerateSpawnPos()
    {
        float xPos = Random.Range(-spawnrange, spawnrange);
        float zPos = Random.Range(-spawnrange, spawnrange);
        Vector3 spawnposition = new Vector3(xPos, Enemyprefab.transform.position.y, zPos);
        return spawnposition;
    }
   
}
