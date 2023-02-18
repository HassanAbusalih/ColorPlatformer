using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    /// <summary>
    /// Handles different abilities the player can get. Shared properties are in Abilities, while specific properties are in 
    /// </summary>
    protected Player player;
    [SerializeField] string type;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        UseAbility();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (type == "Dash")
        {
            player.gameObject.AddComponent<Dash>();
            Destroy(gameObject);
        }
        else if (type == "DoubleJump")
        {
            player.gameObject.AddComponent<DoubleJump>();
            Destroy(gameObject);
        }
        else if (type == "WallClimb")
        {
            player.gameObject.AddComponent<WallClimb>();
            Destroy(gameObject);
        }
    }

    public virtual void UseAbility()
    {

    }
}

public class DoubleJump : Abilities
{
    public override void UseAbility()
    {
        player.canJump = true;
        Destroy(this);
    }
}

public class Dash : Abilities
{
    public override void UseAbility()
    {
        player.canDash = true;
        Destroy(this);
    }
}

public class WallClimb : Abilities
{
    [SerializeField] PhysicsMaterial2D friction;
    Collider2D wall;

    public override void UseAbility()
    {
        friction = player.GetComponent<Collider2D>().sharedMaterial;
        StartCoroutine(ClingToWall());
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            wall = collision.gameObject.GetComponent<Collider2D>();
        }
    }

    IEnumerator ClingToWall()
    {
        yield return new WaitUntil(() => wall != null);
        yield return new WaitUntil(() => gameObject.GetComponent<Rigidbody2D>().IsTouching(wall));
        player.canClimb = true;
        wall.sharedMaterial.friction = 1;
        friction.friction = 1;
        if (!gameObject.GetComponent<Rigidbody2D>().IsTouching(wall))
        {
            friction.friction = 0.1f;
            wall.sharedMaterial.friction = 0;
            player.canClimb = false;
            Destroy(this);
        }
    }
}