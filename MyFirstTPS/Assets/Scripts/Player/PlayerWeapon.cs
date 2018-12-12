using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {
    public GameObject []Weapons;
    GameObject _currentGun;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);

        if (_currentGun != null) {

            var droppedGun =Instantiate(_currentGun);

            droppedGun.transform.position = transform.position + transform.forward * 10 + new Vector3(0,0.1f,0);
            droppedGun.transform.rotation = Quaternion.identity;

            droppedGun.name = _currentGun.name;

            _currentGun.SetActive(false);
            
            _currentGun = null;

        }

        for (int i = 0; i < Weapons.Length; i++)
        {
            Debug.Log(Weapons[i].name);
            if (other.name == Weapons[i].name) {

                _currentGun = Weapons[i];
               Weapons[i].SetActive(true);
            }
            else{

                Weapons[i].SetActive(false);
            }
        }
        Destroy(other.gameObject );
    }
    
}
