using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    private BallSpawner ballSpawner;
    private BallProperty property;
    public BallProperty Property { get { return property; } set { property = value; } }
    private Vector3 startPosition;
    private Rigidbody2D ballRigidbody;
    private SpriteRenderer ballSprite;

    private void Awake()
    {
        var parent = transform.parent;
        ballSpawner = parent.GetComponent<BallSpawner>();
        property = new BallProperty();
    }
    private void Start()
    {
        ballRigidbody = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        ballSprite = GetComponent<SpriteRenderer>();
        ballSprite.color = property.Color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out BucketBehaviour bucket))
        {
            StartCoroutine(HitCoroutine(bucket));
        }
        else
        {
            if (ballSpawner.SummaryBallCount > 0)
            {
                ballSpawner.SummaryBallCount--;
                UiView.Instance.DisplayBallCount();
                StartCoroutine(FallBall());
            }
            else
            {
                ballSpawner.BallList.Remove(this);
                ballSpawner.CheckBallCount();
            }
        }
    }
    IEnumerator HitCoroutine(BucketBehaviour bucket)
    {
        yield return new WaitForSeconds(1.0f);
        property.Color = bucket.Property.Color;
        ballSprite.color = property.Color;
        transform.position = startPosition;
        ballRigidbody.velocity = Vector2.zero;
        ScoreView.Instance.AddScore(bucket.Property.ReceiveScore);
    }
    IEnumerator FallBall()
    {
        yield return new WaitForSeconds(1.0f);
        transform.position = startPosition;
        ballRigidbody.velocity = Vector2.zero;
    }
}
public class BallProperty
{
    private Color color = Color.yellow;
    public Color Color { get { return color; } set { color = value; } }
}