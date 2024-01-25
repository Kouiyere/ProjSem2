using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhasePhysics : MonoBehaviour
{
    private GameObject[] grates;
    private int state;
    private void Start()
    {
        grates = GameObject.FindGameObjectsWithTag("Grate");
    }
    // Update is called once per frame
    void Update()
    {
        state = gameObject.GetComponent<PhaseChange>().state;
        if (state == 1 || state == 2 || state == 4)
        {
            foreach (var grate in grates)
            {
                Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), grate.GetComponent<Collider2D>(), true);
            }
        }
        else
        {
            foreach (var grate in grates)
            {
                Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), grate.GetComponent<Collider2D>(), false);
            }
        }

        if (state == 2)
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fan" && state == 2)
        {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 8), ForceMode2D.Force);
        }
    }
}
