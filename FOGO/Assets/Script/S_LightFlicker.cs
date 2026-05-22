using UnityEngine;

public class S_LightFlicker : MonoBehaviour
{
    public Light fireLight;

    [Header("Intensity")]
    public float minIntensity = 0.5f;
    public float maxIntensity = 1f;

    [Header("Range")]
    public float minRange = 4f;
    public float maxRange = 5f;

    [Header("Movement")]
    public float speed = 5f;

    float offset;

    void Start()
    {
        offset = Random.Range(0f, 1000f);

        if (fireLight == null)
            fireLight = GetComponent<Light>();
    }

    void Update()
    {
        float noise = Mathf.PerlinNoise(offset, Time.time * speed);

        fireLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);

        fireLight.range = Mathf.Lerp(minRange, maxRange, noise);
    }
}