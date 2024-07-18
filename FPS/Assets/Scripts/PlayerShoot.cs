using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private const int ammoAmount = 10;

    [SerializeField] private Transform _shootOrigin;
    [SerializeField] private GameObject _bulletPref;

    private Queue<GameObject> _ammo = new Queue<GameObject>();
   
    void Start()
    {
        for (int i = 0; i < ammoAmount; i++)
        {
            GameObject tempbullet = Instantiate(_bulletPref);
            tempbullet.SetActive(false);
            _ammo.Enqueue(tempbullet);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            shoot();
    }
    private void shoot ()
    {
        GameObject tempbullet = GetBullet();
        Rigidbody rb = tempbullet.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.AddForce(_shootOrigin.forward * 10.0f);
    }

    private GameObject GetBullet()
    {
        GameObject tempbullet = _ammo.Dequeue();
        tempbullet.SetActive(true);
        tempbullet.transform.position = _shootOrigin.position;


        _ammo.Enqueue(tempbullet);
        return tempbullet;
    }


}
