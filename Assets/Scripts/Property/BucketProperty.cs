using UnityEngine;

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
