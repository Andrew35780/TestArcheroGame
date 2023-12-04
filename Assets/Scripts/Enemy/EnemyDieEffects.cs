using UnityEngine;

public class EnemyDieEffects : MonoBehaviour
{
    private Object explosion;
    private GameObject explosionRef;

    private void Start() => explosion = Resources.Load("Explosion");

    public void CreateExsplosion(GameObject enemy)
    { 
        explosionRef = (GameObject) Instantiate(explosion, enemy.transform.position, enemy.transform.rotation);
    }

    public void DestroyExplosion() => Destroy(explosionRef);
}
