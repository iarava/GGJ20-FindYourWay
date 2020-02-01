using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class TrackMousPosition : MonoBehaviour
{
    [SerializeField] private float distance = 10f;

    private void Awake()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        var mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        var objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }

    private void OnDestroy()
    {
        Cursor.visible = true;
    }
}
