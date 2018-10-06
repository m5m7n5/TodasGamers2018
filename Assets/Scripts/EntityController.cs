using System;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    public float Speed;
    public GameObject SpriteObject;
    public Animator SpriteAnimator;

    private float AnimationTransitionSpeed = 5;
    private float delayedHorizontalIncrement = 1;
    private float delayedVerticalIncrement = 1;

    private Vector2 directionVector = new Vector2(1, -1);

    public void Move(float horizontalAxis, float verticalAxis)
    {
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
                            new Vector3(horizontalAxis, 0, verticalAxis));
    }

    public void SetPhysics(bool active)
    {
        GetComponent<Rigidbody>().useGravity = active;
        GetComponent<SphereCollider>().isTrigger = !active;
    }
}