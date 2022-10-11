using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;

    public float moveSpeed = 5f;
    Rigidbody2D rb;
    public Camera cam;

    Vector2 lookDirection = new Vector2(1, 0);
    //public GameObject projectilePrefab;
    Vector2 movement;
    Vector2 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);



        if (Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    void Launch()
    {
        Vector2 lookDir = mousePos - rb.position;

        GameObject projectileObject = Instantiate(projectilePrefab, rb.position  * 0.5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(rb.position, 300);

        //animator.SetTrigger("Launch");
    }

}
