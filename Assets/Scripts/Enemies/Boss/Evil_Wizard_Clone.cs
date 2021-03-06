using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evil_Wizard_Clone : MonoBehaviour
{
    public SpriteRenderer sprite;
    GameObject player;
    [SerializeField] Evil_Wizard father;
    Animator cloneAnim;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
        player = GameObject_Manager.instance.player;
        cloneAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (player == null)
        {
            player = GameObject_Manager.instance.player;
        }
        if (father.isHit == true)
        {
            sprite.enabled = false;
        }
        if (sprite.enabled == false)
        {
            return;
        }
        if (player.transform.position.x - transform.position.x < 0)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cloneAnim.SetTrigger("isDead");
            StartCoroutine(LifeTime(0.8f));
        }
    }
    public void Life(float lifeTime)
    {
        StartCoroutine(LifeTime(lifeTime));
    }
    public IEnumerator LifeTime(float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        sprite.enabled = false;
    }
}
