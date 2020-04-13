
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    public GameObject platformPrefab;
    public GameObject player;
    public int numberOfPlatforms = 200;
    public float levelWidth = 3f;
    public float minY = .2f;
    public float maxY = 1.5f;
    public PlayerController pc;

    // Use this for initialization
    void Start()
    {

        Vector3 spawnPosition = new Vector3();
        
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            //MF_AutoPool.Spawn(platformPrefab, spawnPosition, Quaternion.identity);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }

       
    }

  
     public void SpawnAgain()
    {
      
           Vector3 spawnPosition2 = new Vector3();
        
           for (int i = 0; i < numberOfPlatforms; i++)
             {
                 spawnPosition2.y += (player.transform.position.y + Random.Range(minY, maxY));
                 spawnPosition2.x = Random.Range(-levelWidth, levelWidth);
                 MF_AutoPool.Spawn(platformPrefab, spawnPosition2, Quaternion.identity);
                
             }
         }

    }

