using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseChange : MonoBehaviour
{
    [Range(0, 6)]
    private int state;
    //0 = Solide
    //1 = Liquide
    //2 = Gazeux
    //3 = Sol/Liq
    //4 = Liq/Gaz
    //5 = Sol/Gaz
    //6 = Sol/Liq/gaz

    private Vector2 SLPoint = new Vector2(180, 10);
    private Vector2 LGPoint = new Vector2(600, 8) ;
    private Vector2 SGPoint = new Vector2(120, 0);
    private Vector2 Triplepoint = new Vector2(180, 1);

    private void OnTriggerStay2D(Collider2D collision)
    {
        float temp = collision.gameObject.GetComponent<RoomParameter>().temperature;
        float pres = collision.gameObject.GetComponent<RoomParameter>().pressure;
        Vector2 param = new Vector2(temp, pres);
        StateCheck(param);
        Debug.Log(state);
    }

    void StateCheck(Vector2 param)
    {
        if (IsGaz(param) && IsLiquid(param) && IsSolid(param))
        {
            state = 6;
        }
        else if (IsGaz(param) && IsSolid(param))
        {
            state = 5;
        }
        else if (IsGaz(param) && IsLiquid(param))
        {
            state = 4;
        }
        else if (IsLiquid(param) && IsSolid(param))
        {
            state = 3;
        }
        else if (IsGaz(param))
        {
            state = 2;
        }
        else if (IsLiquid(param))
        {
            state = 1;
        }
        else if (IsSolid(param))
        {
            state = 0;
        }
    }

    bool IsGaz(Vector2 param)
    {
        if (param.x <= Triplepoint.x)
        {
            if (param.y <= SGFunction(param.x))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (param.x >= Triplepoint.x)
        {
            if (param.y <= LGFunction(param.x))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    bool IsLiquid(Vector2 param)
    {
        if (param.x >= Triplepoint.x)
        {
            if (param.y >= LGFunction(param.x))
            {
                return true;
            }
            else if (param.y <= SLFunction(param.x))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    bool IsSolid(Vector2 param)
    {
        if (param.x <= Triplepoint.x)
        {
            if (param.y >= SGFunction(param.x))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (param.x >= Triplepoint.x)
        {
            if (param.y >= SLFunction(param.x))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    private float SGFunction(float x)
    {
        float y = ((SGPoint.y - Triplepoint.y) / (SGPoint.x - Triplepoint.x)) * x + (SGPoint.y - SGPoint.x * (((SGPoint.y - Triplepoint.y) / (SGPoint.x - Triplepoint.x))));
        return y;
    }

    private float LGFunction(float x)
    {
        float y = ((LGPoint.y - Triplepoint.y) / (LGPoint.x - Triplepoint.x)) * x + (LGPoint.y - LGPoint.x * (((LGPoint.y - Triplepoint.y) / (LGPoint.x - Triplepoint.x))));
        return y;
    }

    private float SLFunction(float x)
    {
        float y = ((SLPoint.y - Triplepoint.y) / (SLPoint.x - Triplepoint.x)) * x + (SLPoint.y - SLPoint.x * (((SLPoint.y - Triplepoint.y) / (SLPoint.x - Triplepoint.x))));
        return y;
    }
}
