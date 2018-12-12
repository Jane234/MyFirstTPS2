using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Animator _animator;


	// Use this for initialization
	void Start () {

        _animator = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {

        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        _animator.SetFloat("speedX", h*1.75f);
        _animator.SetFloat("speedZ", v*2.8f);

    }
}
