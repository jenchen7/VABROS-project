using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialPicker : MonoBehaviour
{
    public Material[] randomMaterials;

    public GameObject[] players;
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = randomMaterials[Random.Range(0, randomMaterials.Length)];
        
    }
}
