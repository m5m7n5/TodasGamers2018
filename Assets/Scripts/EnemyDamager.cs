using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    public float HopeRecoveryValue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            GameController.Instance.PlayerController.Hope += HopeRecoveryValue;
        }
    }
}