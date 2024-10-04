using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public SkeletonStateMachine StateMachine { get; private set; }

    public SkeletonStartState SkeletonStartState { get; private set; }
    public SkeletonRiseState SkeletonRiseState { get; private set; }
    public SkeletonIdleState SkeletonIdleState { get; private set; }
    public SkeletonHurtState SkeletonHurtState { get; private set; }
    public SkeletonDeadState SkeletonDeadState { get; private set; }
    public SkeletonChaseState SkeletonChaseState { get; private set; }
    public SkeletonAttackState SkeletonAttackState { get; private set; }
    public SkeletonAttack2State SkeletonAttack2State { get; private set; }

    private GameObject player;
    Vector3 playerPos;

    [SerializeField]
    private SkeletonData skeletonData;

    [SerializeField]
    public EnemyHealth enemyHealthThing;

    [SerializeField]
    private GameObject healthBar;

    #region Components
    public Animator Anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public BoxCollider2D skeletonCollider { get; private set; }
    #endregion

    #region Check Transforms

    [SerializeField]
    private Transform attackPoint;
    public bool isFlipped;
    public bool gotHurt = false;
    public float counter = 0f;
    #endregion

    #region Other Variables
    public Vector2 CurrentVelocity { get; private set; }
    //public LayerMask enemyLayers { get; private set; }
    public int FacingDirection { get; private set; }
    public bool isDead;

    public int direction;


    private Vector2 workspace;
    #endregion

    #region Unity Callback Functions
    private void Awake()
    {
        StateMachine = new SkeletonStateMachine();

        SkeletonStartState = new SkeletonStartState(this, StateMachine, skeletonData, "start");
        SkeletonRiseState = new SkeletonRiseState(this, StateMachine, skeletonData, "rise");
        SkeletonIdleState = new SkeletonIdleState(this, StateMachine, skeletonData, "idle");
        SkeletonHurtState = new SkeletonHurtState(this, StateMachine, skeletonData, "hurt");
        SkeletonDeadState = new SkeletonDeadState(this, StateMachine, skeletonData, "dead");
        SkeletonChaseState = new SkeletonChaseState(this, StateMachine, skeletonData, "chase");
        SkeletonAttackState = new SkeletonAttackState(this, StateMachine, skeletonData, "attack");
        SkeletonAttack2State = new SkeletonAttack2State(this, StateMachine, skeletonData, "attack2");

    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        skeletonCollider = GetComponent<BoxCollider2D>();
        enemyHealthThing = GetComponent<EnemyHealth>();

        FacingDirection = 1;
        isDead = false;
        StateMachine.Initialize(SkeletonStartState);
        TurnOffHealthBar();


    }


    private void Update()
    {
        counter += Time.deltaTime;
        CurrentVelocity = rb.velocity;
        StateMachine.CurrentState.LogicUpdate();
        player = GameObject.Find("Player");
        playerPos = player.transform.position;
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    #endregion

    public void SetVelocityZero()
    {
        rb.velocity = Vector2.zero;
        CurrentVelocity = Vector2.zero;
    }

    public void SetVelocityX(float velocity)
    {
        direction = (int)(player.transform.position.x - transform.position.x);
        if(direction > 0)
        {
            workspace.Set(velocity * 1, CurrentVelocity.y);
        }
        if(direction < 0)
        {
            workspace.Set(velocity * -1, CurrentVelocity.y);
        }
        // workspace.Set(velocity * (player.transform.position.x - transform.position.x), CurrentVelocity.y);
        rb.velocity = workspace;
        CurrentVelocity = workspace;
    }

    public void CheckIfShouldFlip()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x < player.transform.position.x && isFlipped)
        {
            Flip();
        }
        else if (transform.position.x > player.transform.position.x && !isFlipped)
        {
            Flip();
        }
    }

    public bool CheckRange()
    {
        return Vector2.Distance(transform.position, playerPos) < skeletonData.range;

    }

    public bool CheckAttackRange()
    {
        return Vector2.Distance(transform.position, playerPos) < skeletonData.attackRange;

    }
    public void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
        if (isFlipped) { isFlipped = false; }
        else if (!isFlipped) { isFlipped = true; }
    }

    public void MoveSkeleton(float velocity)
    {
        workspace.Set((velocity * FacingDirection), rb.velocity.y);
        rb.velocity = workspace;
        CurrentVelocity = workspace;
    }

    public void SkeletonAttack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * skeletonData.attackOffset.x;
        pos += transform.up * skeletonData.attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, skeletonData.attackRange, skeletonData.attackLayer);
        if (colInfo != null)
        {
            colInfo.GetComponent<PlayerHealth>().TakeDamage(skeletonData.attack);
        }
    }
    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * skeletonData.attackOffset.x;
        pos += transform.up * skeletonData.attackOffset.y;

        Gizmos.DrawWireSphere(pos, skeletonData.attackRange);
    }

    public void SkeletonDead()
    {
        isDead = true;
    }

    public void TurnOnHealthBar()
    {
        healthBar.SetActive(true);
    }
    public void TurnOffHealthBar()
    {
        healthBar.SetActive(false);
    }
    public void SetColliderHeight(float height)
    {
        Vector2 center = new Vector2(0f, -0.1f);
        workspace.Set(0.3f, height);


        skeletonCollider.size = workspace;
        skeletonCollider.offset = center;
    }
    public void SetHeightBack(float height)
    {
        Vector2 center = new Vector2(0f, -0.1f);
        workspace.Set(0.15f, height);


        skeletonCollider.size = workspace;
        skeletonCollider.offset = center;
    }

    public void GotHurt() => gotHurt = true;
    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();
    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
}
