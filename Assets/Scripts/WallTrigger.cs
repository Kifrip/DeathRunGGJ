using System.Collections;
using UnityEngine;

public class WallTrigger : MonoBehaviour
{
    private bool isMoving = false;
    public float speed = 3f; //Speed of the wall (3)
    public float pushForce = 600f; // Force of the wall (600)

    IEnumerator MoveWall()
    {
        isMoving = true;

        Vector3 initialPosition = transform.position;
        Vector3 targetPosition = initialPosition + new Vector3(0f, 0f, -4f);

        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(1.0f);

        while (transform.position != initialPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, speed * Time.deltaTime);
            yield return null;
        }

        isMoving = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isMoving)
        {
            StartCoroutine(MoveWall());
            Debug.Log("Player entered the trigger!");
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision!!!!");
        // TODO: Need FIx. Tag is not correct but it seems this part doesn't work either way
        if (collision.gameObject.CompareTag("Person"))
        {
            Rigidbody otherRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            if (otherRigidbody != null)
            {
                Vector3 pushDirection = collision.contacts[0].point - transform.position;
                pushDirection = -pushDirection.normalized; // Нормализуем направление
                otherRigidbody.AddForce(pushDirection * pushForce, ForceMode.Impulse);
            }
        }
    }
}

