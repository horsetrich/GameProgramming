using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{

    public Vector2 RawMovementInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }
    public bool JumpInput { get; private set; }
    public bool JumpInputStop { get; private set; }
    public bool DefendInput { get; private set; }
    public bool DefendInputStop { get; private set; }
    public bool AttackInput { get; private set; }

    

    [SerializeField]
    private float inputHoldTime = 0.2f;
    [SerializeField]

    private float jumpInputStartTime;

    private float defendInputStartTime;
    


    private void Update()
    {
        CHeckJumpInputHoldTime();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();

        if(Mathf.Abs(RawMovementInput.x) > 0.5f)
        {
            NormInputX = (int)(RawMovementInput * Vector2.right).normalized.x;
        }
        else
        {
            NormInputX = 0;
        }

        if(Mathf.Abs(RawMovementInput.y) > 0.5f)
        {
            NormInputY = (int)(RawMovementInput * Vector2.up).normalized.y;
        }
        else
        {
            NormInputY= 0;
        }

    }

    public void OnDefendInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            DefendInput = true;
            DefendInputStop = false;
            defendInputStartTime = Time.time;
        }
    }


    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            JumpInput = true;
            JumpInputStop = false;
            jumpInputStartTime = Time.time;
        }

        if (context.canceled)
        {
            JumpInputStop = true;
        }
    }

    public void OnAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AttackInput = true;
        }
        if (context.canceled)
        {
            AttackInput = false;
        }
    }

    public void UseDefendInput() => DefendInput = false;

    public void UseAttackInput() => AttackInput = false;

    public void UseJumpInput() => JumpInput = false;
    


    private void CHeckJumpInputHoldTime()
    {
        if (Time.time >= jumpInputStartTime + inputHoldTime)
        {
            JumpInput = false;
        }
    }
}
