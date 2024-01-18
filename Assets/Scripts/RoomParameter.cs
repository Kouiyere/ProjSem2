using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomParameter : MonoBehaviour
{
    [Range(0f, 600f)]
    public float temperature = 300f;
    [Range(0f, 10f)]
    public float pressure = 5f;
}
