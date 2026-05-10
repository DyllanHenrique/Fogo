using UnityEngine;

public class Script_Player : MonoBehaviour
{
    public float speed = 5f;
    public Vector3 movRef;
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
        movRef = move * speed * Time.deltaTime * 10;
        controller.Move(move * speed * Time.deltaTime);
    }
}
