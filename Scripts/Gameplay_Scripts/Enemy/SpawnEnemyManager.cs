using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyManager : MonoBehaviour
{
    [SerializeField] SpawnerEnemy[] spawners;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine(SincronizeSpawner());
    }

    IEnumerator SincronizeSpawner()
    {
        foreach (SpawnerEnemy spawn in spawners)
        {
            spawn.CoroutineMediator();
            yield return new WaitForSeconds(5f);
        }
    }
}
