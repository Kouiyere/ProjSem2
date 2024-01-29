using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationRay : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            Debug.Log(hit.collider.gameObject);

            if (hit.collider.gameObject.tag == "Fan")
            {
                hit.collider.gameObject.GetComponent<FanActivation>().activated = !hit.collider.gameObject.GetComponent<FanActivation>().activated;
            }
        }
    }
}
