using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float forcePower;

    [SerializeField]
    private Rigidbody rb;

    private InputAction moveAction;
    private Vector2 moveValue;

    [SerializeField]
    private int point;
    public int Point
    {
        get { return point; }
        set { point = value; }
    }

    [SerializeField]
    private int hp;
    public int HP
    {
        get { return hp; }
        set { hp = value; }
    }

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MoveLeftOrRight();

        if (transform.position.y < -100f && HP > 0)
        {
            Die();
        }
    }

    private void Die()
    {
        HP = 0;
        UIManager.instance.ShowNotiText($"You are dead!\nPoints: {Point}");
        Time.timeScale = 0f;
        UIManager.instance.ShowHideRestartButton(true);
    }

    private void MoveLeftOrRight()
    {
        moveValue = moveAction.ReadValue<Vector2>();
        rb.AddForce(moveValue.x * Vector3.right * forcePower);
    }
}