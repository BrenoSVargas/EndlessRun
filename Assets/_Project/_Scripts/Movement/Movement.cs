using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

    }
    public void MoveToRole(float xPos)
    {
        StopAllCoroutines();
        StartCoroutine(MoveTo(xPos));
    }

    public void Jump()
    {
        _rigidbody.AddForce(Vector3.up * 6f, ForceMode.Impulse);
    }

    IEnumerator MoveTo(float xPos)
    {
        Vector3 startPos = transform.localPosition;
        Vector3 targetPos = new Vector3(xPos, transform.localPosition.y, transform.localPosition.z);

        while (Vector3.Distance(transform.localPosition, new Vector3(xPos, transform.localPosition.y, transform.localPosition.z)) > 0.01f)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(xPos, transform.localPosition.y, transform.localPosition.z), 5f * Time.deltaTime);

            yield return null;
        }

        transform.localPosition = new Vector3(xPos, transform.localPosition.y, transform.localPosition.z);
        yield return null;

    }
}
