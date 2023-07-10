using UnityEngine;
using KinematicCharacterController.Examples;
using System;

public class UpgradeSkill : MonoBehaviour
{
    public ExampleCharacterController characterController;
    public AutoAimShoot autoAimScript;

    private void Start()
    {
        characterController = GetComponent<ExampleCharacterController>();
        autoAimScript = GetComponent<AutoAimShoot>();
    }

    public void FastUpgrade()
    {
        Debug.Log("�u an �arp��ma oldu ve h�z artt�r�ld�");
        characterController.MaxStableMoveSpeed = (int)Math.Round(characterController.MaxStableMoveSpeed * 1.1f);
    }
    public void DemageUpgrade()
    {
        autoAimScript.DemageChange(); //Pause men�den �a��r�lacak �ekilde haz�r
    }

    public void JumpUpgrade()
    {
        characterController.JumpUpSpeed = (int)Math.Round(characterController.JumpUpSpeed * 1.1f);
    }
}
