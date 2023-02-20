using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// Handles player controls and movement, as well as level completion.
    /// </summary>
    [SerializeField] GameObject victoryPanel;
    Rigidbody2D rb;
    bool canJump;
    public bool canDoubleJump;
    public bool canDash;
    public bool canClimb;
    [SerializeField] float maxSpeed;
    [SerializeField] float speed;
    [SerializeField] float jumpHeight;
    [SerializeField] float dashSpeed;
    [SerializeField] KeyCode up;
    [SerializeField] KeyCode down;
    [SerializeField] KeyCode left;
    [SerializeField] KeyCode right;
    [SerializeField] KeyCode jump;
    [SerializeField] KeyCode dash;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (!victoryPanel.activeSelf)
        //{
            Controls();
        //}
    }

    private void Controls()
    {
        if (Input.GetKey(up) && canClimb)
        {
            rb.velocity += new Vector2(0, speed);
        }
        if (Input.GetKey(down) && canClimb)
        {
            rb.velocity += new Vector2(0, -speed);
        }
        if (Input.GetKey(left))
        {
            rb.velocity += new Vector2(-speed, 0);
            transform.right = new Vector2(-1, 0);
        }
        if (Input.GetKey(right))
        {
            rb.velocity += new Vector2(speed, 0);
            transform.right = new Vector2(1, 0);
        }
        if (Input.GetKey(dash) && canDash)
        {
            rb.AddForce(dashSpeed * transform.right);
            //rb.velocity = new Vector2(dashSpeed * transform.right.x, 0);
            GetComponent<SpriteRenderer>().color = Color.white;
            canDash = false;
        }
        if (!canJump && Input.GetKeyDown(jump) && canDoubleJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.velocity += new Vector2(0, jumpHeight);
            GetComponent<SpriteRenderer>().color = Color.white;
            canDoubleJump = false;
        }
        if (Input.GetKeyDown(jump) && canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.velocity += new Vector2(0, jumpHeight);
            canJump = false;

        }
        if (!Input.GetKey(left) && !Input.GetKey(right))
        {
            rb.velocity = new Vector2((float)(0.95 * rb.velocity.x), rb.velocity.y);
        }
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed), Mathf.Clamp(rb.velocity.y, -10, 10.2f));
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            canJump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            canJump = false;
        }
    }
}
