using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerTwoMovement : MonoBehaviour  // need help in shortening this
{
    public float moveSpeed = 15f;

    public float horizontalMovement = 0f;
    float verticalMovement = 0f;

    public float followSpeed=2.5f;
    public Transform target;

    public int Health=99;
    bool death;
    public int Damage = 33;
    public int currentHealth;
    private Rigidbody2D myBody;

    public GameObject deathEffect;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        currentHealth = 4;
    }

    void FixedUpdate()
    {
        //Move character
        var Distance = Vector3.Distance(transform.position, target.position);
        if (Distance > 0.5 && Distance < 5)
        {
            AIfollow();
        }

    }

    void AIfollow()
    {
        Vector3 temp = Vector3.MoveTowards(transform.position, target.position, followSpeed
                    * Time.fixedDeltaTime);

        Vector3 changeDir = temp - transform.position;

        if (changeDir.x < 0)
            transform.right = Vector2.right;

        if (changeDir.x > 0)
            transform.right = Vector2.left;

        myBody.MovePosition(temp);

    }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if(Health<=0)
        {
            Die();
            death = true;
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        PlayerOneMovement player = coll.GetComponent<PlayerOneMovement>();
        Debug.Log(coll.name);
        if (player != null)
        {
            currentHealth -= 1;
            player.TakeDamage(Damage);
        }
    }
}
