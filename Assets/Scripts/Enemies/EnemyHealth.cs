using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
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

    public GameObject coin;

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
        if(this.gameObject == gameObject.CompareTag("Goblin"))
        {
            gameObject.GetComponent<Goblin>().GotHurt();
        }
        else if (this.gameObject == gameObject.CompareTag("Skeleton"))
        {
            gameObject.GetComponent<Skeleton>().GotHurt();
        }
        enemyHealth = Mathf.Clamp(enemyHealth - value, 0, maxEnemyHealth);

        rb.velocity = Vector2.zero;

        if (enemyHealth <= 0)
        {
            
            if (this.gameObject == gameObject.CompareTag("Goblin"))
            {
                GameObject coinObj = Instantiate(coin, 
                gameObject.transform.position, gameObject.transform.rotation);

                animator.SetBool(animBool, true);
                Destroy(gameObject, 0.5f);
            }
            else if (this.gameObject == gameObject.CompareTag("Skeleton"))
            {
                gameObject.GetComponent<Skeleton>().SkeletonDead();
                if (canKill)
                {
                    GameObject coinObj = Instantiate(coin, 
                gameObject.transform.position, gameObject.transform.rotation);

                    Destroy(gameObject);
                }
            }
            rb.velocity = Vector2.zero;
        }
    }
}
