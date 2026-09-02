using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float zOffset = -10f;
    public bool useSmoothing = true;
    public float smoothSpeed = 5f;
    private float fixedX;
    private float fixedY;

    void Start()
    {
        fixedX = transform.position.x;
        fixedY = transform.position.y;
    }

    void LateUpdate()
    {
        if (target == null) return;
        float desiredZ = target.position.z + zOffset;
        Vector3 targetPosition = new Vector3(fixedX, fixedY, desiredZ);

        if (useSmoothing)
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        else
            transform.position = targetPosition;
    }
}
