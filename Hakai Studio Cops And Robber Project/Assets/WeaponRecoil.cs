using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRecoil : MonoBehaviour
{
    [SerializeField] public float recoilX;
    [SerializeField] public float recoilY;
    [SerializeField] public float recoilZ;

    [SerializeField] public float aimrecoilX;
    [SerializeField] public float aimrecoilY;
    [SerializeField] public float aimrecoilZ;

    [SerializeField] public float snappiness;
    [SerializeField] public float returnSpeed;

    private Vector3 weaponRotation;
    private Vector3 currentRotation;
    private Vector3 targetRotation;

    private void Start()
    {
        weaponRotation = new Vector3(-90f, 180f, 10f);
    }

    void Update()
    {
        targetRotation = Vector3.Lerp(targetRotation, weaponRotation, returnSpeed * Time.deltaTime);
        currentRotation = Vector3.Lerp(currentRotation, targetRotation, snappiness * Time.deltaTime);
        transform.localRotation = Quaternion.Euler(currentRotation);
    }

    public void RecoilFire()
    {
        targetRotation += new Vector3(recoilX, Random.Range(-recoilY, recoilY), Random.Range(-recoilZ, recoilZ));
    }
}