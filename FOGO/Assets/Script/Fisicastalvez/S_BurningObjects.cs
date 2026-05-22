using System.Collections;
using UnityEngine;

public class S_BurningObjects : MonoBehaviour
{
    [Header("Referências")]
    public Transform objectToTrack;

    [Header("Configuração do Burn")]
    public float triggerDistance = 1.2f;
    public float burnSpeed = 0.5f;
    public float maxBurnDistance = 10f;
    public float burnTick = 0.1f;

    private Material mat;
    private bool burning = false;

    private void Awake()
    {
        Renderer rend = GetComponent<Renderer>();

        mat = rend.material;

        mat.SetFloat("_BurnDistance", 0f);
    }

    private void Update()
    {
        if (burning || objectToTrack == null)
            return;

        float distance = Vector3.Distance(
            objectToTrack.position,
            transform.position
        );

        if (distance <= triggerDistance)
        {
            StartBurn();
        }
    }

    void StartBurn()
    {
        burning = true;

        mat.SetVector("_BurnPosition", objectToTrack.position);

        StartCoroutine(Burn());
    }

    IEnumerator Burn()
    {
        while (mat.GetFloat("_BurnDistance") < maxBurnDistance)
        {
            float value = mat.GetFloat("_BurnDistance");

            value += burnSpeed;

            mat.SetFloat("_BurnDistance", value);

            yield return new WaitForSeconds(burnTick);
        }

        yield return new WaitForSeconds(0.2f);

        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        if (mat != null)
        {
            mat.SetFloat("_BurnDistance", 0f);
        }

        burning = false;
    }
}