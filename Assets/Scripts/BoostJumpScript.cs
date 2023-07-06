using UnityEngine;
using KinematicCharacterController.Examples;

public class BoostJumpScript : MonoBehaviour
{
    public ExampleCharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<ExampleCharacterController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BoostJump"))
        {
            Debug.Log("�u an �arp��ma oldu ve z�plama h�z artt�r�ld�");
            characterController.JumpUpSpeed = 20f;
        }
        
    }
}
