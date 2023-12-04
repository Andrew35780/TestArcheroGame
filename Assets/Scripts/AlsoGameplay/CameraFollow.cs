using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    private void Update() => FollowCameraForPlayer();

    public void FollowCameraForPlayer()
    {
        Vector3 targetPosition = new(transform.position.x, transform.position.y, playerController.transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPosition, 1);
    }
}
