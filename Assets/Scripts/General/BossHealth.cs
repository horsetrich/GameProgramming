using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    [SerializeField]
    public int maxEnemyHealth = 10;
    [SerializeField]
    public string animBool;
    public string secondBool;
    public bool canKill;
    public int enemyHealth = 3;
    public bool secondPhase = false;
    private bool isDead = false;
    private Animator animator;
    private Rigidbody2D rb;

    [SerializeField] Slider healthBar;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        enemyHealth = maxEnemyHealth;
        canKill = false;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = enemyHealth;
    }

    public void CanKill() => canKill = true;

    public void CanNotKill() => canKill = false;
    public void GetHurt(int value)
    {
        enemyHealth = Mathf.Clamp(enemyHealth - value, 0, maxEnemyHealth);

        rb.velocity = Vector2.zero;

        if (enemyHealth <= 0)
        {
            gameObject.GetComponent<BossSpirit>().SecondPhase();
            rb.velocity = Vector2.zero;
            if (!secondPhase)
            {
                enemyHealth = maxEnemyHealth;
            }
            secondPhase = true;
        }
        if (secondPhase && enemyHealth <= 0)
        {
            isDead = true;
            gameObject.GetComponent<BossSpirit>().BossIsDead();
        }
    }
}
