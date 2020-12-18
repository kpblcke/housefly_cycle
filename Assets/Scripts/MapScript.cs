using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    public List<Road> roads;
    public int curRoad = 0;
    public float worldSpeed = 30f;
    public float loopTime = 60f;
    [SerializeField]
    private float minSize = 20f;

    [SerializeField]
    private int minObstacles = 20;
    
    public List<GameObject> obstacles;

    // Start is called before the first frame update
    void Start()
    {
        generateMap();
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

    void generateMap()
    {
        float lastPos = minSize;

        for (int i = 0; i < minObstacles; i++)
        {
            List<GameObject> useRoads = new List<GameObject>();
            int rng = Random.Range(0, 6);
            switch (rng)
            {
                case 0: 
                    useRoads.Add(roads[0].gameObject);
                    break;
                case 1: 
                    useRoads.Add(roads[1].gameObject);
                    break;
                case 2: 
                    useRoads.Add(roads[2].gameObject);
                    break;
                case 3: 
                    useRoads.Add(roads[0].gameObject);
                    useRoads.Add(roads[1].gameObject);
                    break;
                case 4: 
                    useRoads.Add(roads[1].gameObject);
                    useRoads.Add(roads[2].gameObject);
                    break;
                case 5: 
                    useRoads.Add(roads[0].gameObject);
                    useRoads.Add(roads[2].gameObject);
                    break;
            }
            
            lastPos += minSize;
            float y = Random.Range(lastPos, lastPos + minSize * 10);
            lastPos = y;
            foreach (var road in useRoads)
            {
                Vector3 position = road.transform.position;
                position.z = lastPos;
                Instantiate(obstacles[Random.Range(0, obstacles.Capacity)], position, Quaternion.identity, road.transform);
            }
        }

    }
}
