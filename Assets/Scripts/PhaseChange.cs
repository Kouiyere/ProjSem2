using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseChange : MonoBehaviour
{
    [Range(0, 6)]
    public int state;
    //0 = Solide
    //1 = Liquide
    //2 = Gazeux
    //3 = Sol/Liq
    //4 = Liq/Gaz
    //5 = Sol/Gaz
    //6 = Sol/Liq/gaz

    private Vector2 SLPoint = new Vector2(180, 10);
    private Vector2 LGPoint = new Vector2(600, 9) ;
    private Vector2 SGPoint = new Vector2(120, 1);
    private Vector2 Triplepoint = new Vector2(180, 2);

    private void OnTriggerStay2D(Collider2D collision)
    {
        float temp = collision.gameObject.GetComponent<RoomParameter>().temperature;
        float pres = collision.gameObject.GetComponent<RoomParameter>().pressure;
        Vector2 param = new Vector2(temp, pres);
        StateCheck(param);
    }

    void StateCheck(Vector2 param)
    {
        if (param == Triplepoint)
        {
            state = 6;
        }
        else if (param == SGPoint)
        {
            state = 5;
        }
        else if (param == LGPoint)
        {
            state = 4;
        }
        else if (param == SGPoint)
        {
            state = 3;
        }
        else if (IsGaz(param))
        {

        }
    }

    bool IsGaz(Vector2 param)
    {
        if (param.x < SGPoint.x)
        {
            return false;
        }
        else if (param.y > LGPoint.y)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
