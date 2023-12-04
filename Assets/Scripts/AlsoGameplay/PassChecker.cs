using UnityEngine;

public class PassChecker : MonoBehaviour
{
    [SerializeField] private EnemySpawner spawner;
    [SerializeField] private GameObject exit;

    private void Update()
    {
        if (spawner.enemies.Count == 0)
            exit.SetActive(true);
    }
}
