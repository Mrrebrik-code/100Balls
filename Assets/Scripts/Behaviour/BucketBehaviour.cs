using UnityEngine;
using DG.Tweening;

public class BucketBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Ease moveEase;
    private BucketProperty property;
    public BucketProperty Property { get { return property; } private set { property = value; } }

    private void Awake()
    {
        property = new BucketProperty();
    }
    private void Start()
    {
        speed = 5.0f;
        moveEase = Ease.Linear;
        Move();
        var sprite = GetComponent<SpriteRenderer>();
        sprite.color = property.Color;
    }
    private void Move()
    {
        transform
            .DOMoveX(-transform.position.x, speed)
            .OnComplete(DestroyBucket)
            .SetEase(moveEase);
    }
    private void DestroyBucket()
    {
        Destroy(gameObject);
    }
}