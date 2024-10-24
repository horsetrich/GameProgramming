using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    private Camera cam;

    [SerializeField] private PlayerHealth playerHealth;
    // [SerializeField] private GameManager gameManager;


    public Vector2 RawMovementInput { get; private set; }
    public Vector2 RawDashDirectionInput{get;private set;}
    public Vector2Int DashDirectionInput{get;private set;}

    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }
    public bool JumpInput { get; private set; }
    public bool JumpInputStop { get; private set; }
    public bool DefendInput { get; private set; }
    public bool DefendInputStop { get; private set; }
    public bool AttackInput { get; private set; }
    public bool DashInput {get;private set;}
    public bool DashInputStop{get;private set;}

    public bool PotionInput{get;private set;}




    [SerializeField]
    private float inputHoldTime = 0.2f;
    [SerializeField]

    private float jumpInputStartTime;
    private float dashInputStartTime;

    private float defendInputStartTime;
    
    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        cam = Camera.main;
    }

    private void Update()
    {
        CHeckJumpInputHoldTime();
        CheckDashInputHoldTime();
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

    public void OnDashInput(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            DashInput = true;
            DashInputStop = false;
            dashInputStartTime = Time.time;
        }
        else if(context.canceled)
        {
            DashInputStop = true;
        }
    }

    public void OnDashDirectionInput(InputAction.CallbackContext context)
    {
        RawDashDirectionInput = context.ReadValue<Vector2>();

        if(playerInput.currentControlScheme == "Keyboard")
        {
            RawDashDirectionInput = cam.ScreenToWorldPoint((Vector3)RawDashDirectionInput) - transform.position;
        }

        DashDirectionInput = Vector2Int.RoundToInt(RawDashDirectionInput.normalized);
    }

    public void OnPotionInput(InputAction.CallbackContext context)
    {
        if (context.started && GameManager.GetInstance().potions >= 1 
        && playerHealth.health < 8) //if button is pressed and you have potions AND 
        //your health isn't maxxed out
        {
            GameManager.GetInstance().potions--;
            playerHealth.AddHealth(3f);
        }
    }

    public void UseDefendInput() => DefendInput = false;

    public void UseAttackInput() => AttackInput = false;

    public void UseJumpInput() => JumpInput = false;

    public void UseDashInput() => DashInput = false;
    


    private void CHeckJumpInputHoldTime()
    {
        if (Time.time >= jumpInputStartTime + inputHoldTime)
        {
            JumpInput = false;
        }
    }
    private void CheckDashInputHoldTime()
    {
        if(Time.time >= dashInputStartTime + inputHoldTime)
        {
            DashInput = false;
        }
    }

}
