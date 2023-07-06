using UnityEngine;
using KinematicCharacterController.Examples;
using System;

public class Controller : MonoBehaviour
{
    public ExampleCharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<ExampleCharacterController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BoostFast"))
        {
            Debug.Log("�u an �arp��ma oldu ve h�z artt�r�ld�");
            characterController.MaxStableMoveSpeed = (int)Math.Round(characterController.MaxStableMoveSpeed * 1.1f);
        }

    }
}
