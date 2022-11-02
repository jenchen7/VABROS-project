using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon;

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
        
    }

    void SelectWeapon() {
        int i=0;
        foreach(Transform weapon in transform) {

            if (i==selectedWeapon) {
                weapon.gameObject.SetActive(true);
            }
            else{
                weapon.gameObject.SetActive(false);
            }

            i++;

        }
    }

    public void SwitchWeapon(int weapon) {
        selectedWeapon = weapon;
        SelectWeapon();
    }
}
