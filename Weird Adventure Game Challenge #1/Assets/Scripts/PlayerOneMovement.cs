using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    attack,
    idle
}

public class PlayerOneMovement : MonoBehaviour
{
    public float moveSpeed = 0.01f;
    public Animator animator;
    public PlayerState currentState;

    public Vector3 change;

    public int Health=99;
    bool death;

    public GameObject deathEffect;
    Rigidbody2D myBody;
    Fire fire;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        change.y = Input.GetAxisRaw("Vertical") * moveSpeed;

        if (Input.GetButtonDown("Fire1") && 
            currentState != PlayerState.attack)
        {
            StartCoroutine(AttackCo());
        }
        else if (currentState == PlayerState.walk)
        {
            UpdateAnimationAndMove();
        }

        //// Shorten this
        if (Mathf.Abs(change.x) > 0f)
            animator.SetFloat("Speed", Mathf.Abs(change.x));
        else
            animator.SetFloat("Speed", Mathf.Abs(change.y));

        //if (Input.GetAxis("Vertical") > 0f|| Input.GetAxis("Vertical") > 0f )
            //fire.shootingPoint.transform.eulerAngles = new Vector3(0, 0, 90);

        //if (Mathf.Abs(change.x) > 0f)
            //fire.shootingPoint.transform.rotation = Quaternion.identity;
    }

    void FixedUpdate()
    {
        //Move character
        if (change.x < 0)
            transform.right = Vector2.left;

        if (change.x > 0)
            transform.right = Vector2.right;

        UpdateAnimationAndMove();
    }

    void UpdateAnimationAndMove()
    {
        myBody.MovePosition(transform.position + change *
                         moveSpeed * Time.fixedDeltaTime);

        if (change != Vector3.zero)
        {
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("Attack", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("Attack", false);
        yield return new WaitForSeconds(0.01f);
        currentState = PlayerState.walk;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0)
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
}
