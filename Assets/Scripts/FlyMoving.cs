using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMoving : MonoBehaviour
{
    [SerializeField]
    private Transform _currentRoad;
    
    [SerializeField]
    private Transform _nextRoad;

    [SerializeField]
    private bool changingRoad;

    [SerializeField] 
    private float timeToChangeRoad = 0.3f;

    private PlayerFly _playerFly;
    
    // Start is called before the first frame update
    void Start()
    {
        _playerFly = PlayerFly.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void chaneRoad(Transform toRoad)
    {
        if (changingRoad || _playerFly.IsDead)
        {
            return;
        }

        changingRoad = true;
        _nextRoad = toRoad;
        StartCoroutine(changeRoadCoroutine());
    }

    private IEnumerator changeRoadCoroutine()
    {
        float routineTime = 0f;
        while (routineTime < timeToChangeRoad)
        {
            transform.position = Vector3.Lerp(_currentRoad.transform.position, _nextRoad.transform.position, routineTime / timeToChangeRoad);
            routineTime += Time.deltaTime;
            yield return new WaitForSeconds(0.001f);
        }
        
        changingRoad = false;
        _currentRoad = _nextRoad;
        _nextRoad = null;
        transform.position = _currentRoad.transform.position;
    }
}
