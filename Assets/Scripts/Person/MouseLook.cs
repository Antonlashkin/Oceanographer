using UnityEngine;

public class MouseLook : MonoBehaviour
{

    [SerializeField] enum RotationAxis
    {
        MouseX,
        MouseY
    }

    [SerializeField] RotationAxis axes;

    [SerializeField] float sensivityHor = 9.0f;
    [SerializeField] float sensivityVert = 9.0f;

    [SerializeField] float minVert = -90.0f;
    [SerializeField] float maxVert = 90.0f;

    private float _rotationX = 0;


    void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            rigidbody.freezeRotation = true;
        }
    }

    
    void Update()
    {
        if (axes == RotationAxis.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensivityHor, 0);
        }
        else
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);

            float rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }
}
