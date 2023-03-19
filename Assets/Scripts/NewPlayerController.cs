using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerController : BasePlayerController
{
    private RunnerControls _controls;
    // Start is called before the first frame update
    private void Awake()
    {
        _controls = new RunnerControls();
    }
    protected override void Start()
    {
        base.Start();
        _controls.Player.Jump.performed += _ => Jump();
    }
    private void OnEnable()
    {
        _controls.Player.Enable();
    }
    private void OnDisable()
    {
        _controls.Player.Disable();
    }
    private void OnDestroy()
    {
        _controls.Dispose();
    }


    private void FixedUpdate()
    {
        
        var direction = _controls.Player.SideMove.ReadValue<float>() * _sideSpeed + Time.fixedDeltaTime;
        if (direction == 0f) return;
        _body.velocity += direction * transform.right;
    }

}
