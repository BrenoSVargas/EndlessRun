using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float _jumpForce = 6f;
    [SerializeField] float _speedToChangeRole = 6f;

    [SerializeField] private VoidEventChannelSO _jumpChannelEvent;
    [SerializeField] private FloatEventChannelSO _horizontalChannelEvent;

    private Rigidbody _rigidbody;

    public void Initialize(float jumpForce, VoidEventChannelSO jumpChannelEvent, FloatEventChannelSO horizontalChannelEvent)
    {
        _jumpChannelEvent = jumpChannelEvent;
        _horizontalChannelEvent = horizontalChannelEvent;
        _jumpForce = jumpForce;
        Awake();
    }
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

    }

    private void MoveToRole(float xPos)
    {
        StopAllCoroutines();
        StartCoroutine(MoveTo(xPos));
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

    private IEnumerator MoveTo(float xPos)
    {
        Vector3 startPos = transform.localPosition;
        Vector3 targetPos = new Vector3(xPos, transform.localPosition.y, transform.localPosition.z);

        while (Vector3.Distance(transform.localPosition, new Vector3(xPos, transform.localPosition.y, transform.localPosition.z)) > 0.01f)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(xPos, transform.localPosition.y,
                transform.localPosition.z), _speedToChangeRole * Time.deltaTime);

            yield return null;
        }

        transform.localPosition = new Vector3(xPos, transform.localPosition.y, transform.localPosition.z);
        yield return null;

    }

    private void EnableEvents()
    {

        _jumpChannelEvent.OnEventRaised += Jump;
        _horizontalChannelEvent.OnEventRaised += MoveToRole;
    }

    private void DisableEvents()
    {

        _jumpChannelEvent.OnEventRaised -= Jump;
        _horizontalChannelEvent.OnEventRaised -= MoveToRole;
    }

    private void OnEnable()
    {
        EnableEvents();
    }

    private void OnDisable()
    {
        DisableEvents();
    }
}
