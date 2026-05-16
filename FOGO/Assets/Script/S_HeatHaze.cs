using UnityEngine;

public class S_HeatHaze : MonoBehaviour
{
    void LateUpdate()
    {
        Vector3 direction = Camera.main.transform.position - transform.position;
        direction.y = 0;

        transform.rotation = Quaternion.LookRotation(-direction);
    }
}
