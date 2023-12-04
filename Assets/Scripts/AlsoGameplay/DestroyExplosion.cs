using System.Collections;
using UnityEngine;

public class DestroyExplosion : MonoBehaviour
{
    private void OnEnable() => StartCoroutine(DestroySelf());

    private IEnumerator DestroySelf()
    {

        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
