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
        else if (other.CompareTag("House"))
        {
            UICanvasController.Instance.ShowGiveGiftMessage(other.transform.position + new Vector3(0, 2, 0));
            PlayerController.ClosestHouse = other.gameObject;
        }
        else if (other.CompareTag("Gift"))
        {
            UICanvasController.Instance.ShowPickGiftMessage(other.transform.position + new Vector3(0, 2, 0));
            PlayerController.ClosestGift = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("House"))
        {
            UICanvasController.Instance.DeactivateGiveGiftMessage();
            PlayerController.ClosestHouse = null;
        }
        else if (other.CompareTag("Gift"))
        {
            UICanvasController.Instance.DeactivatePickGiftMessage();
            PlayerController.ClosestGift = null;
        }
    }
}