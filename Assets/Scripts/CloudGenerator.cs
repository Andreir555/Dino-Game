using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 40f;

    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private Transform levelPart_1;
    [SerializeField] private Transform player;
    private Vector3 lastEndPosition;

    private void Awake()
    {
        lastEndPosition = levelPart_Start.Find("EndPosition").position;
        SpawnLevel();

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            //Spawn more roads
            SpawnLevel();
        }
    }

    private void SpawnLevel()
    {
        lastEndPosition += new Vector3(player.position.x + RandomizeDistanceFromPlayer(), 0);
        Transform lastLevelPartTransform = SpawnLevel(lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }
    private Transform SpawnLevel(Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart_1, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }

    private float RandomizeDistanceFromPlayer()
    {
        return Random.Range(5f, 10f);
    }
    

}
