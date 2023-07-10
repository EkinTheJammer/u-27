using UnityEngine;
using System;

public class UpgradeDroneSkill : MonoBehaviour
{
    public AutoAimShootDrone autoAimDroneScript;

    private void Start()
    {
        autoAimDroneScript = GetComponent<AutoAimShootDrone>();
    }
    public void DroneDemageUpgrade()
    {
        //Debug.Log("Upgrade skill ekran�nda geldi ve DroneDemageUpgrade fonksiyonu i�erisinde �u an");
        autoAimDroneScript.DroneDemageChange(); //Pause men�den �a��r�lacak �ekilde haz�r 
    }

}
