using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public GameObject SpriteObject;
    public Animator SpriteAnimator;

    private float _prevHorizontalAxis;
    private float _prevVerticalAxis;

    // Use this for initialization
    void Start()
    {
        _prevHorizontalAxis = 1;
        _prevVerticalAxis = -11;
    }

    // Update is called once per frame
    void Update()
    {
        bool flipedChange = false;
        if (_prevHorizontalAxis > 0 && Input.GetAxis("Horizontal") < 0)
        {
            flipedChange = true;
            _prevHorizontalAxis = -1;
        }
        else if (_prevHorizontalAxis < 0 && Input.GetAxis("Horizontal") > 0)
        {
            flipedChange = true;
            _prevHorizontalAxis = 1;
        }
        else if (_prevVerticalAxis > 0 && Input.GetAxis("Vertical") < 0)
        {
            flipedChange = true;
            _prevVerticalAxis = -1;
        }
        else if (_prevVerticalAxis < 0 && Input.GetAxis("Vertical") > 0)
        {
            flipedChange = true;
            _prevVerticalAxis = 1;
        }

        if (flipedChange)
        {
            StartFlip();
        }

        transform.Translate(Speed * Time.deltaTime *
                            new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
    }

    //True right, false left
    public void StartFlip()
    {
        SpriteAnimator.SetBool("OneSide", !SpriteAnimator.GetBool("OneSide"));
    }
}