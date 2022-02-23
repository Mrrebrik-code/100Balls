using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GlassBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Ease moveEase;

    private void Start()
    {
        speed = 5.0f;
        moveEase = Ease.Linear;
        Move();
    }
    private void Move()
    {
        transform
            .DOMoveX(-transform.position.x, speed)
            .OnComplete(DestroyObject)
            .SetEase(moveEase);
    }
    private void DestroyObject()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out IceBehaviour iceBehaviour))
        {
            iceBehaviour.transform.parent = gameObject.transform;
        }
    }
}