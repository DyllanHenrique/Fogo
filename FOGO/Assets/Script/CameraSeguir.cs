using UnityEngine;

public class CameraSeguir : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(20, 20, -20);
    public float smoothSpeed = 5f;

    void LateUpdate()
    {

        if (target == null) return;
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.LookAt(target);

        transform.rotation = Quaternion.Euler(30f, 45f, 0f);
    }
}
