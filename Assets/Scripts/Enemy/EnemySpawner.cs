using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPrefabs = new(2);
    [SerializeField] private Transform enemyHolder;

    public List<EnemyHealth> enemies = new();

    private void Start()
    {
        for (int i = 0; i < Random.Range(1, 4); i++)
        {
            var enemy = Instantiate(enemyPrefabs[Random.Range(0, 2)], new Vector3(Random.Range(-1.6f, 1.6f), 0.1f, Random.Range(5.5f, 11f)), Quaternion.identity, enemyHolder).GetComponent<EnemyHealth>();
            enemies.Add(enemy);
        }
    }
}
