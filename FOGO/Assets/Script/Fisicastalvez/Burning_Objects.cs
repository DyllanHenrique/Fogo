using UnityEngine;

[ExecuteInEditMode]
public class Burning_Objects : MonoBehaviour
{
    public Transform m_objectToTrack = null;

    public Material m_materialRef = null;
    public Renderer m_renderer = null;

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
        if(m_materialRef != null)
        {
            MaterialRef.SetVector("_BurnPosition", m_objectToTrack.position);
        }
    }

    private void OnDestroy()
    {
        m_renderer = null;
        if(m_materialRef != null)
            Destroy(m_materialRef);

        m_materialRef =null;
    }
}