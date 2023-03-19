using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BasePlayerController : MonoBehaviour
{
    protected Rigidbody _body;
    private bool _canJump;
    [SerializeField] float _forwardSpeed = 5f;
    [SerializeField] protected float _sideSpeed = 5f;
    [SerializeField] private float _jumpForce = 50f;
    
    protected virtual void Start()
    {
        StartCoroutine(MoveForward());
        _body = GetComponent<Rigidbody>();
    }
    protected void Jump()
    {
        if (!_canJump) return;
        _body.AddForce(transform.up * _jumpForce, ForceMode.Force);
    }

    private void OnCollisionStay(Collision collision)
    {
        _canJump = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        _canJump = false;
    }

    private IEnumerator MoveForward ()
    {
        while(true)
        {
            transform.position += transform.forward * _forwardSpeed * Time.deltaTime;
            yield return null;
        }
    }
}
