using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanActivation : MonoBehaviour
{
    public bool activated = false;
    private BoxCollider2D wind;

    // Start is called before the first frame update
    void Start()
    {
        wind = gameObject.GetComponent<BoxCollider2D>();
        wind.enabled = activated;
    }

    // Update is called once per frame
    void Update()
    {
        wind.enabled = activated;

        if (activated)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;

        }
    }
}
