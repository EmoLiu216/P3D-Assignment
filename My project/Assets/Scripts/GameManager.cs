using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public GameObject prefab;

    public float spawnTime = 3f;
    public float nextSpawnTime = 2f;

    
    
    void Start()
    {
     
    }

    public void PlayGame() {
        Debug.Log("Play");
        RubbishPrefab();
      
    }

    private void RubbishPrefab() 
    {     
        List<int> result = new List<int>();
        while (result.Count < SpawnPoints.Length)
        {
            int Index = Random.Range(0, SpawnPoints.Length);
            if (!result.Contains(Index))
            {
                result.Add(Index);
                Instantiate(prefab, SpawnPoints[Index].position, SpawnPoints[Index].rotation).transform.name= "Rubbish"+Index;
            }          
        
        }
    }

    
}
