using UnityEngine;

public class Burning_Objects : MonoBehaviour
{
    [Header("Material")]
    public Renderer meshRenderer;

    Material mat;

    [Header("Burn Settings")]
    public float burnSpeed = 2f;
    public float maxRadius = 5f;

    float currentRadius = 0f;

    bool burning = false;

    void Start()
    {
        mat = meshRenderer.material;

        mat.SetFloat("_BurnRadius", 0);
    }

    void Update()
    {
        if (!burning)
            return;

        currentRadius += Time.deltaTime * burnSpeed;

        mat.SetFloat("_BurnRadius", currentRadius);

        if (currentRadius >= maxRadius)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (burning)
            return;

        if (other.CompareTag("Player"))
        {
            burning = true;

            Vector3 hitPoint =
                other.ClosestPoint(transform.position);

            mat.SetVector("_BurnPosition", hitPoint);

            currentRadius = 0;

            mat.SetFloat("_BurnRadius", currentRadius);
        }
    }
}