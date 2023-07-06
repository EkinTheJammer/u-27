using UnityEngine;
using KinematicCharacterController.Examples;
using System;

public class UpgradeSkill : MonoBehaviour
{
    public ExampleCharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<ExampleCharacterController>();
    }

    public void FastUpgrade()
    {
        Debug.Log("�u an �arp��ma oldu ve h�z artt�r�ld�");
        characterController.MaxStableMoveSpeed = (int)Math.Round(characterController.MaxStableMoveSpeed * 1.1f);
    }

    public void JumpUpgrade()
    {
        characterController.JumpUpSpeed = (int)Math.Round(characterController.JumpUpSpeed * 1.1f);
    }
}
