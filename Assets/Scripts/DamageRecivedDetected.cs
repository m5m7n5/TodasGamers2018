using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageRecivedDetected : MonoBehaviour
{
    public PlayerController PlayerController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Hitted");
            PlayerController.Hope -= 2;
            PlayerController.Horror += 0.5f;
        }
    }
}