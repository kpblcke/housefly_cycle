using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    public List<Road> roads;
    public int curRoad = 0;
    public float worldSpeed = 10f;
    public float loopTime = 15f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(loopCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.back * worldSpeed * Time.deltaTime;
    }

    IEnumerator loopCoroutine()
    {
        yield return new WaitForSeconds(loopTime);
        transform.position = Vector3.zero;
    }
}
