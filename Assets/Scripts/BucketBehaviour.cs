using System.Collections;
using System.Collections.Generic;
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
public class BucketProperty
{
    public enum BucketColor
    {
        Yellow,
        Red,
        Green,
        Blue
    }
    public BucketColor bucketColor = BucketColor.Yellow;
    public Color Color
    {
        get
        {
            switch (bucketColor)
            {
                case BucketColor.Red: return Color.red;
                case BucketColor.Blue: return Color.blue;
                case BucketColor.Green: return Color.green;
                default: return Color.yellow;
            }
        }
    }
    public int ReceiveScore
    {
        get
        {
            switch (bucketColor)
            {
                case BucketColor.Red: return 2;
                case BucketColor.Blue: return 3;
                case BucketColor.Green: return 4;
                default: return 1;
            }
        }
    }
}