using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyState : MonoBehaviour
{
    [SerializeField]
    private Road curRoad;

    [SerializeField] 
    private PlayerFly _playerFly;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changePath(Road path)
    {
        _playerFly.transform.position = path.transform.position;
    }

    public void Loop()
    {
        transform.position = Vector3.zero;
    }
    
}