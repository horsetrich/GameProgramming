using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField]
    public int maxEnemyHealth = 10;
    [SerializeField]
    public string animBool;
    public string secondBool;
    public bool canKill;
    public int enemyHealth = 0;
    private Animator animator;
    private Rigidbody2D rb;

    [SerializeField] FloatingHealthBar healthBar;

    private void Awake()
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>();
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
        healthBar.UpdateHealthBar(enemyHealth);
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

        }
    }
}
