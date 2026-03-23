using UnityEngine;

public class Script_Player : MonoBehaviour
{
    public float speed = 5f;
    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(h, 0, v);

        move = Quaternion.Euler(0, 45, 0) * move;
        controller.Move(move * speed * Time.deltaTime);
    }
}
