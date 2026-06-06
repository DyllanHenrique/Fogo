using System.Collections;
using UnityEngine;
using DG.Tweening;

public class S_BurningObjects : MonoBehaviour
{
    [Header("Referências")]
    public Transform objectToTrack;

    [Header("Configuração do Burn")]
    public float triggerDistance = 1.2f;
    public float burnSpeed = 0.5f;
    public float maxBurnDistance = 10f;
    public float burnTime = 3f;

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

        Burnear();
    }
    void Burnear() 
    {
        DOTween.To(
            () => mat.GetFloat("_BurnDistance"),
            x => mat.SetFloat("_BurnDistance", x),
            maxBurnDistance,
            burnTime
        ).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
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