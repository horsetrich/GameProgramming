using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class Goblin : MonoBehaviour
{

    public GoblinStateMachine StateMachine {  get; private set; }
    private GameObject player;
    public GoblinIdleState GoblinIdleState { get; private set; }
    public GoblinChaseState GoblinChaseState { get; private set; }
    public GoblinPatrol GoblinPatrol { get; private set; }
    public GoblinAttackState GoblinAttackState { get; private set; }
    public GoblinHurtState GoblinHurtState { get; private set; }
    public GoblinDeadState GoblinDeadState { get; private set; }

    public GameObject goblinEyes;
    public bool isFlipped;
    public bool gotHurt = false;
    public float counter = 0f;
    public EnemyHealth enemyHealthThing;
    public int currentHealth;

    [SerializeField]
    private GoblinData goblinData;

    public Animator Anim { get; private set; }
    public Rigidbody2D rb {  get; private set; }
    public BoxCollider2D Collider2D { get; private set; }
    public SpriteRenderer sprite {  get; private set; }


    public Vector2 GoblinCurrentVelocity { get; private set; }
    private Vector2 goblinWorkspace;

    public int FacingDirection { get; private set; }
    public bool hasLineOfSight = false;
    public Vector2 playerPos;

    private void Awake()
    {
        StateMachine = new GoblinStateMachine();

        GoblinIdleState = new GoblinIdleState(this, StateMachine, goblinData, "goblinIdle");
        GoblinChaseState = new GoblinChaseState(this, StateMachine, goblinData, "goblinChase");
        GoblinPatrol = new GoblinPatrol(this, StateMachine, goblinData, "goblinPatrol");
        GoblinAttackState = new GoblinAttackState(this, StateMachine, goblinData, "goblinAttack");
        GoblinHurtState = new GoblinHurtState(this, StateMachine, goblinData, "goblinHurt");
        GoblinDeadState = new GoblinDeadState(this, StateMachine, goblinData, "goblinDead");



    }

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Collider2D = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();

        FacingDirection = 1;
        isFlipped = false;
        currentHealth = enemyHealthThing.maxEnemyHealth;

        StateMachine.Initialize(GoblinIdleState);

    }

    // Update is called once per frame
    void Update()
    {
        

        GoblinCurrentVelocity = rb.velocity;
        StateMachine.CurrentState.LogicUpdate();
        counter += Time.deltaTime;
        player = GameObject.Find("Player");
        playerPos = player.transform.position;

    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    public void SetVelocityZero()
    {
        rb.velocity = Vector2.zero;
        GoblinCurrentVelocity = Vector2.zero;
    }

    public void SetVelocityX(float velocity)
    {
        goblinWorkspace.Set(velocity * (player.transform.position.x - transform.position.x), GoblinCurrentVelocity.y);
        rb.velocity = goblinWorkspace;
        GoblinCurrentVelocity = goblinWorkspace;
    }


    public bool CheckRange()
    {
        return Vector2.Distance(transform.position, playerPos) < goblinData.range;

    }

    public bool CanSeePlayer()
    {
        bool val = false;

        Vector2 endPos = goblinEyes.transform.position + (Vector3.right * goblinData.seeingDistance * FacingDirection);
        RaycastHit2D hit = Physics2D.Linecast(goblinEyes.transform.position, endPos, goblinData.attackMask);

        if(hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                return hit;
            }
            else { return false; }
        }
        return val;
    }

    public void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
        if (isFlipped) { isFlipped = false; }
        else if (!isFlipped) { isFlipped= true; }
    }

    public void StayOnCourse()
    {
        if (rb.velocity.x > 0)
        {
            Flip();
        }
    }

    public void CheckIfShouldFlip()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x < player.transform.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x > player.transform.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    public void MoveGoblin(float velocity)
    {
        goblinWorkspace.Set((velocity * FacingDirection), rb.velocity.y);
        rb.velocity = goblinWorkspace;
        GoblinCurrentVelocity = goblinWorkspace;
    }

    public void GoblinAttack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * goblinData.attackOffset.x;
        pos += transform.up * goblinData.attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, goblinData.range, goblinData.attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<PlayerHealth>().TakeDamage(goblinData.goblinDamage);
        }
    }
    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * goblinData.attackOffset.x;
        pos += transform.up * goblinData.attackOffset.y;

        Gizmos.DrawWireSphere(pos, goblinData.range);
    }

    public void GotHurt() => gotHurt = true;

    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();
    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

}
