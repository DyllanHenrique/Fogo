using System.Collections;
using UnityEngine;

[ExecuteInEditMode]
public class Burning_Objects : MonoBehaviour
{
    public Transform m_objectToTrack = null;

    public Material m_materialRef = null;
    public Renderer m_renderer = null;
    public float valorBurn;
    private Vector3 objPos;
    private bool Burning = false;


    public Renderer Renderer
    {
        get
        {
            if (m_renderer == null)
                m_renderer = GetComponent<Renderer>();

            return m_renderer;
        }
    }

    public Material MaterialRef
    {
        get
        {
            if (m_materialRef  == null)
                m_materialRef = Renderer.material;

            return m_materialRef;
        }
    }

    private void Awake()
    {
       m_renderer = this.GetComponent<Renderer>();
        m_materialRef = m_renderer.material;

    }
    private void Update()
    {
        float distance = (m_objectToTrack.position - this.transform.position).magnitude;
        if (distance <= 1.5 && !Burning)
        {
            Burning = true;
            StartedBurn(m_objectToTrack.position);
        }
    }

    private void OnDestroy()
    {
        m_renderer = null;
        if(m_materialRef != null)
            DestroyImmediate(m_materialRef);

        m_materialRef = null;
    }

    public void StartedBurn(Vector3 posBurn) 
    {
        MaterialRef.SetVector("_BurnPosition", m_objectToTrack.position);
        StartCoroutine(Burn());
    }
    IEnumerator Burn() 
    {
        while (MaterialRef.GetFloat("_BurnDistance") < 10f) 
        {
            float RefValor = MaterialRef.GetFloat("_BurnDistance");
            RefValor += 0.5f;
            MaterialRef.SetFloat("_BurnDistance", RefValor);

            yield return new WaitForSeconds(0.1f);
        }
    }
}