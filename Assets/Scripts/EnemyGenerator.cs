using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GamePoints puncte_puncte;

    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 20f;

    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private Transform[] levelPart_1;
    [SerializeField] private Transform player;
    [SerializeField] private Transform flyingEnemy;
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
            if (BirdExists())
            {
                int fly_or_ground = Random.Range(0, 2);
                if (fly_or_ground == 1)
                {
                    lastEndPosition += new Vector3(10f, 0f);
                    SpawnFlyingEnemy();
                }
                else SpawnLevel();
            }
        }
    }


    private void SpawnLevel()
    {
        RandomizerX();
        Transform lastLevelPartTransform = SpawnLevel(lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }
    private Transform SpawnLevel(Vector3 spawnPosition)
    {
        int randomNumber = Random.Range(0, 10);
        Transform levelPartTransform = Instantiate(levelPart_1[randomNumber], spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
    private void RandomizerX()
    {
        if(puncte_puncte.time < 500)
            lastEndPosition += new Vector3(Random.Range(8f, 30f), 0);
        else
            lastEndPosition += new Vector3(Random.Range(20f, 50f), 0);
    }

    private void SpawnFlyingEnemy()
    {
        Vector3 flyPosition = player.position;
        if (puncte_puncte.time < 500) flyPosition += new Vector3(28f, 0);
        else flyPosition += new Vector3(53f, 0);
        flyPosition = new Vector3(flyPosition.x, RandomizerY());
        Instantiate(flyingEnemy, flyPosition, Quaternion.identity);
    }
    private float RandomizerY()
    {
        float randomNumber = Random.Range(0f, 1f);
        if (randomNumber > 0.66f)
        {
            Debug.Log(randomNumber);
            return 4f;
        }
        if (randomNumber < 0.33f)
        {
            Debug.Log(randomNumber);
            return 0.5f;
        }
        Debug.Log(randomNumber);
        return 2f;
    }
    private bool BirdExists()
    {
        if (flyingEnemy.position.x < (player.position.x + 200) && flyingEnemy.position.x > player.position.x) return false;
        else return true;
    }

}
