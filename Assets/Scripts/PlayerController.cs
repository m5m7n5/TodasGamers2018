using Assets.Scripts;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public EntityController EntityController;
    public GameObject ClosestGift;
    public GameObject ClosestHouse;
    public float SwordDistance = 15;
    public float AttackCooldown = 1f;
    public float AttackDuration = 0.75f;

    public GameObject Sword;

    public AudioClip TerrorClip;
    public AudioSource AudioSource;

    private int _giftsDelivered;
    private int _currentPickedGifts;

    private float _hope;
    private float _horror;

    private float _attackCooldownCounter;
    private float _attackDurationCounter;

    private Vector2 _movementVector;

    public int GiftsDelivered
    {
        get { return _giftsDelivered; }
        set
        {
            UICanvasController.Instance.GiftsDelivered(value);
            _giftsDelivered = value;
            if (_giftsDelivered >= 15)
            {
                GameController.Instance.Win();
            }
        }
    }

    public int CurrentPickedGifts
    {
        get { return _currentPickedGifts; }
        set
        {
            UICanvasController.Instance.CurrentGifts(value);
            _currentPickedGifts = value;
        }
    }

    public float Hope
    {
        get { return _hope; }
        set
        {
            UICanvasController.Instance.Hope.value = value;
            _hope = value;
            if (_hope <= 0)
            {
                GameController.Instance.Lost();
            }
        }
    }

    public float Horror
    {
        get { return _horror; }
        set
        {
            UICanvasController.Instance.Horror.value = value;
            if (_horror < 25 && _horror + value > 25)
            {
                AudioSource.clip = TerrorClip;
                AudioSource.Play();
            }

            _horror = value;
            if (_horror >= 50)
            {
                GameController.Instance.Lost();
            }
        }
    }

    // Use this for initialization
    void Start()
    {
        _hope = GameSettingsManager.LevelStartingHope;
        _horror = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _movementVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _movementVector.Normalize();
        EntityController.Move(_movementVector.x, _movementVector.y);
        Hope = _hope - Time.deltaTime * (1f + 1.0f / GameSettingsManager.LevelMaxHorror);
        if (ClosestGift != null && Input.GetKeyDown(KeyCode.E))
        {
            CurrentPickedGifts++;
            UICanvasController.Instance.DeactivatePickGiftMessage();
            Destroy(ClosestGift);
            ClosestGift = null;
        }
        else if (ClosestHouse != null && Input.GetKeyDown(KeyCode.E) && CurrentPickedGifts > 0)
        {
            GiftsDelivered++;
            CurrentPickedGifts--;
        }

        _attackCooldownCounter += Time.deltaTime;
        _attackDurationCounter += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_attackCooldownCounter > AttackCooldown)
            {
                _attackCooldownCounter = 0;
                _attackDurationCounter = 0;
                SpawnSword();
            }
        }

        if (_attackDurationCounter > AttackDuration)
        {
            _attackDurationCounter = 0;
            DispawnSword();
        }
    }

    private void SpawnSword()
    {
        Sword.SetActive(true);
        Sword.transform.localPosition =
            new Vector3(_movementVector.x, 0, _movementVector.y) * SwordDistance + new Vector3(0, 2, 0);
        Debug.Log(Vector2.Angle(new Vector2(1, 0), _movementVector));
        Sword.transform.localRotation =
            Quaternion.Euler(0, -Vector2.SignedAngle(new Vector2(1, 0), _movementVector), 0);
    }

    private void DispawnSword()
    {
        Sword.SetActive(false);
    }
}