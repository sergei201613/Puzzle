using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public LayerMask BlockingLayer;
    public float speed;

    private BoxCollider2D boxCollider;
    private Vector2 targetPos;
    private RaycastHit2D hit;
    private Vector2 dir = Vector2.down;
    private bool move = false;
    private Vector3 lastPos;
    private Transform transformComp;

    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        targetPos = transform.position;
        lastPos = transform.position;
        transformComp = GetComponent<Transform>();
    }

    void Update()
    {
        boxCollider.enabled = false;
        hit = Physics2D.Raycast(transformComp.position, dir, Mathf.Infinity, BlockingLayer);
        boxCollider.enabled = true;

        targetPos = hit.point - (dir * 0.5f);
        MoveToTargetUpdate();

        if (lastPos == transformComp.position)
        {
            move = false;
        }
        lastPos = transformComp.position;

        Debug.DrawLine(transformComp.position, targetPos, Color.green, 5f);
    }

    private void MoveToTargetUpdate()
    {
        if (move)
        {
            transformComp.position = Vector2.MoveTowards(transformComp.position, targetPos, speed * Time.deltaTime);
        }
    }

    public void MoveBox(Vector2 newDir)
    {
        if (!move)
        {
            move = true;
            dir = newDir;
        }
    }
}