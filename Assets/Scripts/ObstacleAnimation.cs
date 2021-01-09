using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://docs.unity3d.com/Packages/com.unity.probuilder@4.0/api/UnityEngine.ProBuilder.Axis.html
public enum Axis
{
    x,
    y,
    z
}

public class ObstacleAnimation : MonoBehaviour
{
    [SerializeField] private Axis axisEnum;
    [SerializeField] private float speed = 0.2f;
    [SerializeField] private float strength = 3f;

    private float randomOffset;

    private void Start()
    {
        randomOffset = Random.Range(0f, 4f);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 pos = transform.position;

        var newPos = Mathf.Sin(Time.time * speed + randomOffset) * strength;

        switch (axisEnum)
        {
            case Axis.x:
                pos.x = newPos;
                break;
            case Axis.y:
                pos.y = newPos; ;
                break;
            case Axis.z:
                pos.z = newPos;
                break;
            default:
                break;
        }
        transform.position = pos;
    }
}
