using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerFly : Singleton<PlayerFly>
{
    [SerializeField] 
    private Animator _animator;

    [SerializeField]
    private FlyState curState;

    [SerializeField]
    private Rigidbody _rigidbody;

    [SerializeField]
    private bool isDead = false;

    public bool IsDead
    {
        get => isDead;
        set => isDead = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        curState = FindObjectOfType<FlyState>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setDead()
    {
        isDead = true;
        _animator.SetBool("dead", isDead);
        _rigidbody.isKinematic = false;
    }
}
