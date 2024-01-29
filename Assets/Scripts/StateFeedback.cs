using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateFeedback : MonoBehaviour
{
    private int state;
    public GameObject solidSprite;
    public GameObject liquidSprite;
    public GameObject gazSprite;

    // Update is called once per frame
    void Update()
    {
        state = gameObject.GetComponent<PhaseChange>().state;

        if (state == 0 || state == 3 || state == 5 || state == 6)
        {
            solidSprite.SetActive(true);
            liquidSprite.SetActive(false);
            gazSprite.SetActive(false);
        }
        else if (state == 1 || state == 4)
        {
            solidSprite.SetActive(false);
            liquidSprite.SetActive(true);
            gazSprite.SetActive(false);
        }
        else if (state == 2)
        {
            solidSprite.SetActive(false);
            liquidSprite.SetActive(false);
            gazSprite.SetActive(true);
        }
    }
}
