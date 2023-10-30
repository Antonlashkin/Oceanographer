using UnityEngine;

public class MoveShark : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] float obstackeForwardRange = 50.0f;
    [SerializeField] float obstackeDownRangeMin = 50.0f;
    [SerializeField] float obstackeDownRangeMax = 100.0f;

    public static bool Atacked = false;

    void Update()
    {
        Debug.Log(speed);
        transform.Translate(speed * Time.deltaTime, 0, 0);

        Ray forwardRay = new Ray(transform.position, transform.right);
        Ray downRay = new Ray(transform.position, new Vector3(0, -1, 0));
        Ray personRay1 = new Ray(transform.position, new Vector3(1, -1, 0));
        Ray personRay2 = new Ray(transform.position, transform.right);
        RaycastHit downHit;
        RaycastHit forwardHit;
        RaycastHit personHit1;
        RaycastHit personHit2;


        Physics.SphereCast(personRay1, 10f, out personHit1);
        Physics.SphereCast(personRay2, 10f, out personHit2);
        if (personHit1.transform.GetComponent<CharacterController>() != null || personHit2.transform.GetComponent<CharacterController>() != null) 
        {
            if (!Atacked)
            {
                Atacked = true;
                speed *= 3;
                GameObject person = personHit1.transform.GetComponent<CharacterController>() != null ? personHit1.transform.gameObject : personHit2.transform.gameObject;
                GoToPerson(person);
            }
        }
        else
        {
            if (Physics.SphereCast(forwardRay, 0.75f, out forwardHit))
            {
                if (transform.position.y < 250 && transform.rotation.eulerAngles.y == 270)
                {
                    transform.Translate(0, speed * Time.deltaTime, 0);
                }
                else if (forwardHit.distance < obstackeForwardRange)
                {
                    if (Atacked)
                    {
                        Atacked = false;
                        speed /= 3;
                    }
                    transform.Rotate(0, -90, 0);
                }
            }



            if (Physics.SphereCast(downRay, 0.75f, out downHit))
            {
                if (downHit.distance < obstackeDownRangeMin)
                {
                    transform.Translate(0, speed * Time.deltaTime, 0);
                }
                else if (downHit.distance > obstackeDownRangeMax)
                {
                    transform.Translate(0, -speed * Time.deltaTime, 0);
                }
            }
        }
    }

    private void GoToPerson(GameObject person)
    {
        var direction = person.transform.position - this.transform.position;
        float angleHor = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;
        float directXZ = Mathf.Sqrt(Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.z, 2));
        float angleVert = Mathf.Atan2(direction.y, directXZ) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, -angleHor, angleVert);
    }
}
