using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelGenerator : MonoBehaviour
{
    public int range1, range2;
    int levelCount = 0;
    [SerializeField] private List<Transform> levelPartMediumList,levelPartHardList;
    [SerializeField] private Transform levelPart_Start;
    infiniteRunner player;
    [SerializeField] private List<Transform> levelPartEasyList;
    infiniteRunner score;
    private Vector3 lastEndPosition;
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 200f;


    private void Awake()
    {
        lastEndPosition = levelPart_Start.Find("EndPosition").position;
        int startingSpawnLevelParts = 5;
        for (int i = 0; i < startingSpawnLevelParts; i++)
        {
            SpawnLevelPart();
        }



    }
    public void Update()
    {
        if (Vector3.Distance(GameObject.FindGameObjectWithTag("player").transform.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {

           
                SpawnLevelPart();
          

        }
    }
    public void SpawnLevelPart()
    {
        Transform chosenLevelPart;
       
        chosenLevelPart = levelPartEasyList[Random.Range(0, levelPartEasyList.Count)];
        if (levelCount > 10)
        {   
            chosenLevelPart = levelPartMediumList[Random.Range(0, levelPartMediumList.Count)];
        }
  


        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
        levelCount++;

    }
    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;


    }



}
