using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 0.1f;
    public int Damage = 20;
    public Rigidbody2D fireBody;
    PlayerOneMovement player;

    // Start is called before the first frame update
    void Start()
    {
        //look up how and why
        //if(Mathf.Abs(player.change.x) > 0)
        fireBody.velocity = transform.right * speed;

        //if(Mathf.Abs(player.change.y) > 0)
        //fireBody.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerTwoMovement beeEnemy = hitInfo.GetComponent<PlayerTwoMovement>();

        if (beeEnemy != null)
            beeEnemy.TakeDamage(Damage);

        Destroy(gameObject);
    }
}
