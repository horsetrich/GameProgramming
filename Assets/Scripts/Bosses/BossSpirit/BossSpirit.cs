using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

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
    public BossStartState BossStartState { get; private set; }
    public BossSpiritFloor BossSpiritFloor { get; private set; }
    public BossSecondSummon BossSecondSummon { get; private set; }
    public BossSpiritHurt BossSpiritHurt { get; private set; }
    public BossDeadState BossDeadState { get; private set; }

    [SerializeField]
    private BossSpiritData bossData;

    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public BoxCollider2D BossCollider { get; private set; }

    public Vector2 CurrentVelocity { get; private set; }
    private Vector2 workspace;
    [SerializeField]
    private GameObject hurtPoint;
    [SerializeField]
    private Transform attackPoint;
    [SerializeField]
    public GameObject player;
    [SerializeField]
    private GameObject summonSpirit;
    [SerializeField]
    private GameObject summonSpiritTwo;
    [SerializeField]
    private GameObject summonSpiritThree;
    [SerializeField]
    private Transform summonPointOne;
    [SerializeField]
    private Transform summonPointTwo;
    [SerializeField]
    private Transform summonPointThree;
    [SerializeField]
    private Transform damagePoint;
    [SerializeField]
    private GameObject damageThing;

    public Transform teleportOne;
    public Transform teleportTwo;
    public Transform teleportThree;

    public int FacingDirection { get; private set; }
    public bool isFlipped;
    private float distance;
    public float counter = 0;
    public bool teleState = false;
    public bool chaseState = false;
    public bool telePlay = false;
    public bool stop = false;
    public int teleport = 0;
    public bool secondPhase = false;
    public bool isDead = false;
    public Vector3 scale = new Vector3(1f, 1f, 1f);

    private void Awake()
    {
        StateMachine = new BspiritStateMachine();

        BossSpiritIdle = new BossSpiritIdle(this, StateMachine, bossData, "bossIdle");
        BossSpiritAppear = new BossSpiritAppear(this, StateMachine, bossData, "bossAppear");
        BossSpiritAttack = new BossSpiritAttack(this, StateMachine, bossData, "bossAttack");
        BossSpiritDead = new BossSpiritDead(this, StateMachine, bossData, "death");
        BossSpiritSecondPhase = new BossSpiritSecondPhase(this, StateMachine, bossData, "secondPhase");
        BossSpiritSkill = new BossSpiritSkill(this, StateMachine, bossData, "bossSkill");
        BossSpiritSummon = new BossSpiritSummon(this, StateMachine, bossData, "bossSummon");
        BossSpiritStart = new BossSpiritStart(this, StateMachine, bossData, "takeShape");
        BossStartState = new BossStartState(this, StateMachine, bossData, "start");
        BossSpiritFloor = new BossSpiritFloor(this, StateMachine, bossData, "bossSkill");
        BossSecondSummon = new BossSecondSummon(this, StateMachine, bossData, "bossSummon");
        BossSpiritHurt = new BossSpiritHurt(this, StateMachine, bossData, "bossSkill");
        BossDeadState = new BossDeadState(this, StateMachine, bossData, "death");
    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        rb = GetComponent<Rigidbody2D>();
        BossCollider = GetComponent<BoxCollider2D>();
        FacingDirection = 1;

        StateMachine.Initialize(BossStartState);

    }

    private void Update()
    {
        CurrentVelocity = rb.velocity;
        StateMachine.CurrentState.LogicUpdate();
        counter += Time.deltaTime;
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
            Debug.Log("Hitting");
            enemy.GetComponent<PlayerHealth>().TakeDamage(bossData.bossDamage);
        }
    }
    private void OnDrawGizmosSelected() => Gizmos.DrawWireSphere(attackPoint.position, bossData.attackRange);

    public void CheckIfShouldFlip()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x < player.transform.position.x && isFlipped)
        {
            Flip();
            isFlipped = false;
        }
        else if (transform.position.x > player.transform.position.x && !isFlipped)
        {
            Flip();
            isFlipped = true;
        }
    }

    private void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    public void SummonEnemy()
    {
        Instantiate(summonSpirit, summonPointOne.position, Quaternion.identity);
        Instantiate(summonSpiritTwo, summonPointTwo.position, Quaternion.identity);
        Instantiate(summonSpiritThree, summonPointThree.position, Quaternion.identity);
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
    public void GetPlayer()
    {
        Vector2 spiritPos = transform.position;
        distance = Vector2.Distance(transform.position, player.transform.position);

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, bossData.speed * Time.deltaTime);
    }

    public void SecondPhase() => secondPhase = true;
    public void BossIsDead() => isDead = true;
    public void TeleportOne() => transform.position = teleportOne.transform.position;

    public void TeleportTwo() => transform.position = teleportTwo.transform.position;

    public void TeleportThree() => transform.position = teleportThree.transform.position;

    public void TeleportPlayer() => transform.position = player.transform.position;

    public void TurnOnHeart() => hurtPoint.SetActive(true);
    public void TurnOffHeart() => hurtPoint.SetActive(false);

    public void MakeThing()
    {
        Instantiate(damageThing, damagePoint.position, Quaternion.identity);
    }

    public void Reward()
    {
        //Instantiate a reward for killing the boss
    }

    public void SelfDestruct()
    {
        Destroy(gameObject, 0.5f);
    }

    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();
    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

}
