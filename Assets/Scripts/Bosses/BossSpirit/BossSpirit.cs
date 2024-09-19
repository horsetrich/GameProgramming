using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;

public class BossSpirit : MonoBehaviour
{
    public BspiritStateMachine StateMachine { get; private set; }

    public BossSpiritIdle BossSpiritIdle { get; private set; }
    public BossSpiritAppear BossSpiritAppear { get; private set; }
    public BossSpiritAttack BossSpiritAttack { get; private set; }
    public BossSpiritDead BossSpiritDead { get; private set; }
    public BossSpiritSkill BossSpiritSkill { get; private set; }
    public BossSpiritSkill BossSpiritSKill {  get; private set; }
    public BossSpiritSecondPhase BossSpiritSecondPhase { get; private set; }
    public BossSpiritSummon BossSpiritSummon { get; private set; }
    public BossSpiritStart BossSpiritStart { get; private set; }

    [SerializeField]
    private BossSpiritData bossData;


    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public BoxCollider2D BossCollider { get; private set; }

    public Vector2 CurrentVelocity { get; private set; }
    private Vector2 workspace;
    [SerializeField]
    private Transform attackPoint;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject summonSpirit;
    [SerializeField]
    private Transform summonPointOne;
    [SerializeField]
    private Transform summonPointTwo;
    [SerializeField]
    private Transform summonPointThree;

    [SerializeField]
    private Transform teleportOne;
    [SerializeField]
    private Transform teleportTwo;
    [SerializeField]
    private Transform teleportThree;

    public int FacingDirection { get; private set; }
    public float counter = 0;
    public Vector3 scale = new Vector3(1f, 1f, 1f);

    private void Awake()
    {
        StateMachine = new BspiritStateMachine();

        BossSpiritIdle = new BossSpiritIdle(this, StateMachine, bossData, "bossIdle");
        BossSpiritAppear = new BossSpiritAppear(this, StateMachine, bossData, "bossAppear");
        BossSpiritAttack = new BossSpiritAttack(this, StateMachine, bossData, "bossAttack");
        BossSpiritDead = new BossSpiritDead(this, StateMachine, bossData, "bossDead");
        BossSpiritSecondPhase = new BossSpiritSecondPhase(this, StateMachine, bossData, "secondPhase");
        BossSpiritSkill = new BossSpiritSkill(this, StateMachine, bossData, "bossSkill");
        BossSpiritSummon = new BossSpiritSummon(this, StateMachine, bossData, "bossSummon");
        BossSpiritStart = new BossSpiritStart(this, StateMachine, bossData, "start");

    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        rb = GetComponent<Rigidbody2D>();
        BossCollider = GetComponent<BoxCollider2D>();

        FacingDirection = 1;

        StateMachine.Initialize(BossSpiritStart);

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

    public void SetVelocityZero()
    {
        rb.velocity = Vector2.zero;
        CurrentVelocity = Vector2.zero;
    }

    public void SetVelocityX(float velocity)
    {
        workspace.Set(velocity, CurrentVelocity.y);
        rb.velocity = workspace;
        CurrentVelocity = workspace;
    }

    public bool CheckRange()
    {
        return Vector2.Distance(transform.position, player.transform.position) < bossData.attackRange;

    }

    public bool BeginFight()
    {
        return Vector2.Distance(transform.position, player.transform.position) < bossData.canSee;
    }

    public void AttackEnemy()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, bossData.attackRange, bossData.playerLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<PlayerHealth>().TakeDamage(bossData.bossDamage);
        }
    }
    private void OnDrawGizmosSelected() => Gizmos.DrawWireSphere(attackPoint.position, bossData.attackRange);

    public void CheckIfShouldFlip(int xInput)
    {
        if (xInput != 0 && xInput != FacingDirection)
        {
            Flip();
        }
    }

    private void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    public void SummonEnemy()
    {
        Instantiate(summonSpirit, summonPointOne, true);
        Instantiate(summonSpirit, summonPointTwo, true);
        Instantiate(summonSpirit, summonPointThree, true);
    }

    public IEnumerator ScaleOverTime(float duration, float scale)
    {
        var startScale = transform.localScale;
        var endScale = Vector3.one * scale;
        var elapsed = 0f;

        while (elapsed < duration)
        {
            var t = elapsed / duration;
            transform.localScale = Vector3.Lerp(startScale, endScale, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = endScale;
    }

    public void TeleportOne() => gameObject.transform.position = teleportOne.position;

    public void TeleportTwo() => gameObject.transform.position = teleportTwo.position;

    public void TeleportThree() => gameObject.transform.position = teleportThree.position;

    public void TeleportPlayer() => gameObject.transform.position = player.transform.position;


    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();
    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

}
