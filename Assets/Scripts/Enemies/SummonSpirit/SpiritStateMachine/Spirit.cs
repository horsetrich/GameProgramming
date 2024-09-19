using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirit : MonoBehaviour
{

    private GameObject player;
    public SpiritStateMachine SpiritStateMachine { get; private set; }

    public SpiritAppearState SpiritAppearState { get; private set; }
    public SpiritIdleState SpiritIdleState { get; private set; }
    public SpiritDieState SpiritDieState { get; private set; }

    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public CircleCollider2D circleCollider { get; private set; }

    [SerializeField]
    private SpiritData spiritData;

    public Vector2 CurrentVelocity { get; private set; }

    private Vector2 workspace;

    private float distance;

    public float counter = 0f;

    public bool isChasing = false;
    public Vector2 playerPos;

    private void Awake()
    {
        SpiritStateMachine = new SpiritStateMachine();

        SpiritAppearState = new SpiritAppearState(this, SpiritStateMachine, spiritData, "spiritStart");
        SpiritIdleState = new SpiritIdleState(this, SpiritStateMachine, spiritData, "spiritIdle");
        SpiritDieState = new SpiritDieState(this, SpiritStateMachine, spiritData, "spiritDie");
    }

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();



        SpiritStateMachine.Initialize(SpiritAppearState);
    }

    private void Update()
    {
        counter += Time.deltaTime;
        SpiritStateMachine.CurrentState.LogicUpdate();
        player = GameObject.Find("Player");
        playerPos = player.transform.position;
    }

    private void FixedUpdate()
    {

    }

    public void GetPlayer()
    {
        Vector2 spiritPos = transform.position;
        distance = Vector2.Distance(transform.position, playerPos);
        Vector2 direction = playerPos - spiritPos;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.position = Vector2.MoveTowards(this.transform.position, playerPos, spiritData.spiritSpeed * Time.deltaTime);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Player"))
        {
             isChasing = true;
        }
    }

    public void SpiritDie()
    {
        gameObject.SetActive(false);
        Destroy(gameObject, 3);
    }

    private void AnimationTrigger() => SpiritStateMachine.CurrentState.AnimationTrigger();

    private void AnimationFinishTrigger() => SpiritStateMachine.CurrentState.AnimationFinishTrigger();
}
