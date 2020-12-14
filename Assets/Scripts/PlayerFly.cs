using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerFly : MonoBehaviour
{
    [SerializeField] 
    private Animator _animator;

    [SerializeField]
    private FlyState curState;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        curState = FindObjectOfType<FlyState>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setDead()
    {
        _animator.SetBool("dead", true);
    }
}
