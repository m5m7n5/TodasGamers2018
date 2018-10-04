using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public GameObject SpriteObject;
    public Animator SpriteAnimator;

    private float AnimationTransitionSpeed = 5;
    private float delayedHorizontalIncrement = 1;
    private float delayedVerticalIncrement = 1;

    private Vector2 directionVector = new Vector2(1, -1);

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        if (Math.Abs(horizontalAxis) > 0 || Math.Abs(verticalAxis) > 0)
        {
            directionVector = new Vector2(Math.Sign(horizontalAxis), Math.Sign(verticalAxis));
        }

        delayedHorizontalIncrement = directionVector.x < 0
            ? Math.Max(delayedHorizontalIncrement + Time.deltaTime * AnimationTransitionSpeed * directionVector.x, -1)
            : Math.Min(delayedHorizontalIncrement + Time.deltaTime * AnimationTransitionSpeed * directionVector.x, 1);
        delayedVerticalIncrement = directionVector.y < 0
            ? Math.Max(delayedVerticalIncrement + Time.deltaTime * AnimationTransitionSpeed * directionVector.y, -1)
            : Math.Min(delayedVerticalIncrement + Time.deltaTime * AnimationTransitionSpeed * directionVector.y, 1);

        SpriteAnimator.SetFloat("Horizontal", delayedHorizontalIncrement);
        SpriteAnimator.SetFloat("Vertical", delayedVerticalIncrement);
        transform.Translate(Speed * Time.deltaTime *
                            new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
    }
}