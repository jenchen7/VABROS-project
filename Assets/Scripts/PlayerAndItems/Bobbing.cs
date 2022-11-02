
using UnityEngine;

public class Bobbing : MonoBehaviour

{
    //float intensity = 10.0f;
    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.up * Mathf.Cos(Time.deltaTime) * intensity;
        transform.Rotate(0, 60*Time.deltaTime, 0);
    }
}
