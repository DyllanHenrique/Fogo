using Unity.VisualScripting;
using UnityEngine;

public class Teste_Queimar : MonoBehaviour
{
    private bool Burn = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Burn == true)
        {
            gameObject.SetActive(false);
        }

    }
    private void OnTriggerEnter(Collider Objeto)
    {
        if (Objeto.tag == "Player") {Burn = true;}
    }
    private void OnTriggerStay(Collider ObjEmChamas)
    {
        if (Burn == true)
        {
            if (ObjEmChamas.tag == "Inflamavel")
            {
                ObjEmChamas.GetComponent<Teste_Queimar>().Burn = true;
            }
            else if (ObjEmChamas.tag == "Imortal")
            {
                Debug.Log("Eu sou implacavel");
            }
        }
        }
    private void OnCollisionStay(Collision collision)
    {
        // Debug.Log(collision.collider);
    }
}
