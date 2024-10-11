using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossSlider : MonoBehaviour
{
    private Animator animator;

    public Slider thisSlider;
    private bool isDead;
    private bool startFight;
    private GameObject player;
    private GameObject boss;
    public Vector2 playerPos;
    public Vector2 bossPos;


    public void Start()
    {
        startFight = false;
        animator = GetComponent<Animator>();
        animator.SetBool("goUp", false);
        animator.SetBool("goDown", false);
        boss = GameObject.Find("BossSpirit");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        startFight = BeginFightHealth();
        Animation();
        CheckHealth();

        playerPos = player.transform.position;

        bossPos = boss.transform.position;
    }

    public bool BeginFightHealth()
    {
        if(Vector2.Distance(playerPos, bossPos) < 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Animation()
    {
        animator.SetBool("goUp", false);
        animator.SetBool("goDown", false);
        if (startFight == true)
        {
            animator.SetBool("goUp", true);
            animator.SetBool("goDown", false);
        }
        else if (isDead)
        {
            animator.SetBool("goUp", false);
            animator.SetBool("goDown", true);
        }
    }

    public void CheckHealth()
    {
        if(thisSlider.value == 0)
        {
            isDead = true;
        }
    }

    private void TurnOnHealth() => gameObject.SetActive(true);
    private void TurnOffHealth() => gameObject.SetActive(false);
}
