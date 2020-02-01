using System;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public event Action MoveLeft = delegate { };
    public event Action MoveRight = delegate { };

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }

        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
    }
}


