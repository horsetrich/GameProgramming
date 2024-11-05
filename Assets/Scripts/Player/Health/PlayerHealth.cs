using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{

    [SerializeField]
    private PlayerData playerData;

    public float health;
    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;
    public bool KnockFromRight;
    public int damage = 1;

    [Header("iFrames")]
    [SerializeField] private float healthValue;
    [SerializeField] private AudioSource healthPickup;
    [SerializeField] private AudioSource hurtSound;
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private Player player;
    private SpriteRenderer spriteRend;
    public Image[] hearts;

    DamageHealth damageHealth;


    public Sprite fullHeart;
    public Sprite emptyHeart;


    private Rigidbody2D rb;
    private Animator anim;



    // Start is called before the first frame update
    void Start()

        


    {
       player = GetComponent<Player>();
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        Physics2D.IgnoreLayerCollision(7, 8, false);
        health =  playerData.maxHealth;


        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            spriteRend = GetComponent<SpriteRenderer>();
        }

    }
    public void TakeDamage(int amount)
    {
        //hurtSound.Play();
        //anim.SetTrigger("hurt");
        StartCoroutine(Invunerability());
        if (player.invincible == false)
        {
            health = Mathf.Clamp(health - amount, 0, playerData.maxHealth);
        }
        else { return; }

        if (health <= 0)
        {
            
            Die();

        }


    }


    private void Die()
    {
        //deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        RestartLevel();

        //anim.SetTrigger("death");

    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }






    // Update is called once per frame
    void Update()
    {

          
        

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < playerData.maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        

    }
    private void FixedUpdate()
    {
        
        //if(KBCounter <= 0 && damageHealth.knockPlayer == true)
        //{
          //  if (KnockFromRight == true)
            //{
              //  rb.velocity = new Vector2(-KBForce, KBForce);
            //}

            //if (KnockFromRight == false)
            //{
            //    rb.velocity = new Vector2(KBForce, KBForce);
            //}
            //KBCounter -= Time.deltaTime;
            //damageHealth.knockPlayer = false;
       // }
       
    }




    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(6, 8, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(6, 8, false);

    }


    public void AddHealth(float _value) //takes health data and increases health
    {
        health = Mathf.Clamp(health + _value, 0, playerData.maxHealth);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Health")
        {
            //sends health from the health data from the heart to the AddHealth method
            AddHealth(collision.gameObject.GetComponent<Heart>().healthInc); 

            //deletes the heart game object
            collision.gameObject.SetActive(false);
        }
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spirit") || collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(damage);
        }
    }

}





