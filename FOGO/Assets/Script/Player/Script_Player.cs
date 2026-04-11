using UnityEngine;

public class Script_Player : MonoBehaviour
{
    public float speed = 5f;
    private CharacterController controller;
    private Movimento movimentoControls;
    private void Awake()
    {
        movimentoControls = new Movimento();
    }
    private void OnEnable()
    {
        movimentoControls.Enable();
    }

    private void OnDisable()
    {
        movimentoControls.Disable();
    }

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {

        Vector2 controlRead = movimentoControls.Player.Andar.ReadValue<Vector2>();
        float h = controlRead.x;
        float v = controlRead.y;

        Vector3 move = new Vector3(h, 0, v);
        move = Quaternion.Euler(0, 45, 0) * move;
        controller.Move(move * speed * Time.deltaTime);
    }
}
