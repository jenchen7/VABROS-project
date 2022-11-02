using UnityEngine;
using UnityEngine.UI;

public class AmmoCount : MonoBehaviour
{

    public Text ammoCountText;
    public PlayerAmmo ammoCount;
 
    void Start () {
        ammoCountText = GetComponent<Text>();
        ammoCount = transform.parent.parent.gameObject.GetComponent<PlayerAmmo>(); 
    }
 
    void Update () {
        ammoCountText.text = ammoCount.ammoCount.ToString();
    }
}
