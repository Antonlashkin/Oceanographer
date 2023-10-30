using System.Collections;
using UnityEngine;

public class TakeItem : MonoBehaviour
{
    [SerializeField] float takeDistance = 10.0f;
    Camera _camera;
    void Start()
    {
        _camera = Camera.main;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    private void OnGUI()
    {
        int size = 20;
        float positionX = _camera.pixelWidth/2 - size/2;
        float positionY = _camera.pixelHeight/2 - size/2;
        GUI.Label(new Rect(positionX, positionY, size, size), "*");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.distance < takeDistance)
                {
                    GameObject hitObject = hit.transform.gameObject;
                    if (hitObject.tag == "Note")
                    {
                        Destroy(hitObject);
                    }
                }
            }
        }
    }
}
