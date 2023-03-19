using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldPlayerController : BasePlayerController
{
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Jump();
        var direction = Input.GetAxis("Horizontal") * _sideSpeed + Time.fixedDeltaTime;
        if (direction == 0f) return;
        _body.velocity += direction * transform.right;
    }
}
