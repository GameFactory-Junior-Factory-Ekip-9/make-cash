using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pervanerotater : MonoBehaviour
{
    [SerializeField] float rotationz;
    [SerializeField] GameObject moneysystem;
    float rotationx;
    private void FixedUpdate()
    {
        rotationx += 90 * Time.fixedDeltaTime * moneysystem.GetComponent<money>().hızlevel;
        transform.localRotation=Quaternion.Euler(rotationx, 0, rotationz);
    }
}
