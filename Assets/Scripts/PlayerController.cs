using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputHandler
{
    public Vector2 movement_direction;

    public void Update()
    {
        movement_direction.x = Input.GetAxisRaw("Horizontal");
        movement_direction.y = Input.GetAxisRaw("Vertical");
    }
}

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;

    public float moveSpeed = 5f;
    Rigidbody2D rb;
    public Camera cam;

    Vector2 lookDirection = new Vector2(1, 0);
    //public GameObject projectilePrefab;
    Vector2 mousePos;
    InputHandler input_handler = new InputHandler();

    public int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameObject.layer = 6;
    }

    // Update is called once per frame
    void Update()
    {
        input_handler.Update();

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + input_handler.movement_direction * moveSpeed * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
    void ApplyDamage(int damage)
    {
        health -= damage;
        if (health <= 0) {
            Destroy(gameObject);
            Debug.Log("Lost");
            PlayerPrefs.SetInt("CurrentDifficulty",0);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        }
    }

}
