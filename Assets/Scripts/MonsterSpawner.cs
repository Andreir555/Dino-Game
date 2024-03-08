using System.Collections;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] monsterReference;

    private GameObject spawnedMonster;
    [SerializeField] private Transform leftPos, rightPos;

    private int randomIndex;
    private int randomSide;

    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    // Update is called once per frame
    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);

            spawnedMonster = Instantiate(monsterReference[randomIndex]);
            //left
            if (randomSide == 0)
            {
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Enemy>().speed = Random.Range(4, 10);
            }
            //right
            else
            {
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Enemy>().speed = -Random.Range(4, 10);
            }
        }

    }
}
