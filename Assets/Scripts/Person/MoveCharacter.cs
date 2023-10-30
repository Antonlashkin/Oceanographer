using UnityEngine;

public class MoveCharacter : MonoBehaviour
{

    [SerializeField] float speed = 7.0f;
    [SerializeField] float gravity = -9.8f;
    [SerializeField] float jumpForce = 5.0f;
    [SerializeField] float ascentForce = 7.0f;

    private CharacterController _characterController;
    private Rigidbody _rigidbody;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
       _characterController = GetComponent<CharacterController>();
    }


    void Update()
    {
        if(transform.position.y < 280)
        {
            gravity = 0f;
        }
        else
        {
            gravity = -9.8f;
        }
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        if (Input.GetKey(KeyCode.Space) && transform.position.y < 280)
        {
            movement.y = ascentForce;
        }
        else if (Input.GetKey(KeyCode.LeftShift) && transform.position.y < 280)
        {
            movement.y = - ascentForce;
        }
        else
        {
            movement.y = gravity;
        }
        movement *= Time.deltaTime;

        movement = transform.TransformDirection(movement);
        _characterController.Move(movement);
    }
}
