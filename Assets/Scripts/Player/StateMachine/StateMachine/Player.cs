using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    #region State Variables
    public PlayerStateMachine StateMachine {  get; private set; }

    public PlayerIdleState IdleState { get; private set; }  
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }
    public PlayerLandState LandState { get; private set; }
    public PlayerCrouchIdleState CrouchIdleState { get; private set; }
    public PlayerCrouchMoveState CrouchMoveState { get; private set ; }
    public PlayerDefendState DefendState { get; private set; }
    public AttackState1 AttackState1 { get; private set; }
    public AttackState2 AttackState2 { get; private set; }
    public AttackState3 AttackState3 { get; private set; }

    public PlayerDashState DashState    {get; private set;}

    [SerializeField]
    private PlayerData playerData;

    #endregion

    #region Components
    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public Transform DashDirectionIndicator {get; private set;}
    public BoxCollider2D MovementCollider { get; private set; }
    #endregion

    #region Check Transforms

    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private Transform ceilingCheck;
    [SerializeField]
    private Transform attackPoint;

    #endregion

    #region Other Variables
    public Vector2 CurrentVelocity { get; private set; }
    //public LayerMask enemyLayers { get; private set; }
    public int FacingDirection { get; private set; }
    public bool canAttack = false;
    public bool invincible = false;
    

    private Vector2 workspace;
    #endregion

    #region Unity Callback Functions
    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
        JumpState = new PlayerJumpState(this, StateMachine, playerData, "inAir");
        InAirState = new PlayerInAirState(this, StateMachine, playerData, "inAir");
        LandState = new PlayerLandState(this, StateMachine, playerData, "land");
        CrouchIdleState = new PlayerCrouchIdleState(this, StateMachine, playerData, "crouchIdle");
        CrouchMoveState = new PlayerCrouchMoveState(this, StateMachine, playerData, "crouchMove");
        DefendState = new PlayerDefendState(this, StateMachine, playerData, "defendPlayer");
        AttackState1 = new AttackState1(this, StateMachine, playerData, "attack1");
        AttackState2 = new AttackState2(this, StateMachine, playerData, "attack2");
        AttackState3 = new AttackState3(this, StateMachine, playerData, "attack3");
        DashState = new PlayerDashState(this,StateMachine,playerData, "inAir");
    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        rb = GetComponent<Rigidbody2D>();
        DashDirectionIndicator = transform.Find("DashDirectionIndicator");
        MovementCollider = GetComponent<BoxCollider2D>();

        FacingDirection = 1;

        StateMachine.Initialize(IdleState);
        
    }


    private void Update()
    {
        CurrentVelocity = rb.velocity;
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
    #endregion

    #region Set Functions

    public void SetVelocityZero()
    {
        rb.velocity = Vector2.zero;
        CurrentVelocity = Vector2.zero;
    }

    public void SetVelocity(float velocity, Vector2 angle, int direction)
    {
        angle.Normalize();
        workspace.Set(angle.x * velocity * direction, angle.y * velocity);
        rb.velocity = workspace;
        CurrentVelocity = workspace;
    }

    public void SetVelocity(float velocity,Vector2 direction)
    {
        workspace = direction * velocity;
        rb.velocity = workspace;
        CurrentVelocity = workspace;
    }

    public void SetVelocityX(float velocity)
    {
        workspace.Set(velocity, CurrentVelocity.y);
        rb.velocity = workspace;
        CurrentVelocity = workspace;
    }

    public void SetVelocityY(float velocity)
    {
        workspace.Set(CurrentVelocity.x, velocity);
        rb.velocity = workspace;
        CurrentVelocity = workspace;
    }

    public void MakeInvincible()
    {
        invincible = true;
    }

    public void MakeVincible()
    {
        invincible = false;
    }

    public void AttackEnemy()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, playerData.attackRange, playerData.enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().GetHurt(playerData.playerDamage);
        }
    }
    public void AttackBoss()
    {
        Collider2D[] hitBoss = Physics2D.OverlapCircleAll(attackPoint.position, playerData.attackRange, playerData.bossLayers);

        foreach (Collider2D boss in hitBoss)
        {
            boss.GetComponent<InBetween>().PassAlong(playerData.playerDamage);
        }
    }
    public void HitSwitch()
    {
        Collider2D[] switchHit = Physics2D.OverlapCircleAll(attackPoint.position, playerData.attackRange, playerData.switchLayers);

        foreach (Collider2D hit in switchHit)
        {
            hit.GetComponent<Lever>().TurnOn();
        }
    }
    private void OnDrawGizmosSelected() => Gizmos.DrawWireSphere(attackPoint.position, playerData.attackRange);

    #endregion

    #region Check Functions

    public bool CheckForCeiling()
    {
        return Physics2D.OverlapCircle(ceilingCheck.position, playerData.groundCheckRadius, playerData.whatIsGround);
    }

    public bool CheckIfGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, playerData.groundCheckRadius, playerData.whatIsGround);
    }

    public void CheckIfShouldFlip(int xInput)
    {
        if (xInput != 0 && xInput != FacingDirection)
        {
            Flip();
        }
    }
    public bool CheckIfCanDefending()
    {
        if(playerData.timesDefended == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void CanDefend()
    {
        if (Time.time > playerData.defendCooldown)
        {
            playerData.timesDefended = 0;
        }
    }

    public void CantAttack()
    {
        if (!canAttack && Time.time >= playerData.nextAttackTime)
        {
            canAttack = true;
        }
    }
    public void CanAttack() => canAttack = false;


    #endregion

    #region Other Functions

    public void SetColliderHeight(float height)
    {
        Vector2 center = MovementCollider.offset;
        workspace.Set(MovementCollider.size.x, height);

        center.y += (height - MovementCollider.size.y) / 2;

        MovementCollider.size = workspace;
        MovementCollider.offset = center;
    }

    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

    private void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }
    #endregion
}

