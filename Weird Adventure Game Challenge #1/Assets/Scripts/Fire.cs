using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    //research
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    private Vector3 change;
    public float force = 500f;

    //public float force = 1000f;

    PlayerOneMovement playerOne;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Shoot();

        if (Input.GetAxis("Vertical") > 0f)
        {
            shootingPoint.transform.eulerAngles = new Vector3(0, 0, 90);
            //change position as well
        }

        if (Input.GetAxis("Vertical") < 0f)
        {
            shootingPoint.transform.eulerAngles = new Vector3(0, 0, 270);
            //change position as well
        }


        if (Input.GetAxis("Horizontal") > 0f || Input.GetAxis("Horizontal") > 0f)
            shootingPoint.transform.rotation = Quaternion.identity;
    }

    void Shoot()
    {
        //google more
        //Rigidbody2D fireBody;
        //fireBody = Instantiate(bulletPrefab, shootingPoint.position, 
        //    shootingPoint.rotation) as Rigidbody2D;
        //fireBody.AddForce(shootingPoint.right * force);
        //Instantiate(bulletPrefab, shootingPoint.position,
        //        shootingPoint.rotation);
        //if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("player_back_weaponAttack") ||
        //    this.animator.GetCurrentAnimatorStateInfo(0).IsName("player_idle_back"))

            Instantiate(bulletPrefab, shootingPoint.position,
                shootingPoint.rotation);
    }
}
