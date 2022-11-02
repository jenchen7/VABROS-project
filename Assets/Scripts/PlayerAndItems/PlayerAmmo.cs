using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAmmo : MonoBehaviour
{
    public int ammoCount;
    int maxAmmo = 25;

    public void AddAmmo(int count) {
        ammoCount += count;
        if (ammoCount >= maxAmmo) {
            ammoCount = maxAmmo;
        }
    }

    public void UseAmmo() {
        ammoCount -= 1;
    }

    public int GetAmmoCount() {
        return ammoCount;
    }
}
