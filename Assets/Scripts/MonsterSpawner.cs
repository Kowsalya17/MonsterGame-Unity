using System.Collections;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] MonsterReference;
    private GameObject spawnedMonster;
    [SerializeField] private Transform LeftPos, RightPos;
    private int randomIndex, randomSide;


    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));
            randomIndex = Random.Range(0, MonsterReference.Length);
            randomSide = Random.Range(0, 2);
            spawnedMonster = Instantiate(MonsterReference[randomIndex]);

            if (randomSide == 0)
            {
                spawnedMonster.transform.position = LeftPos.position;
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(4, 10);
            }
            else
            {
                spawnedMonster.transform.position = RightPos.position;
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4, 10);
                //Turning the enemy 
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }

    }
}  
  
