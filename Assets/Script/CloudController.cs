using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cloud
{

    public GameObject cloudObject;
    public Vector3 velocity;
    public float alpha;

    public Cloud(GameObject newCloudObject, Vector3 newVelocity)
    {
        cloudObject = newCloudObject;
        velocity = newVelocity;
    }

}

public class CloudController : MonoBehaviour
{

    public GameObject[] clouds;
    public List<Cloud> sky = new List<Cloud>();
    public int skyMax = 20;
    public int spawnPercent = 2;
    public Vector3 baseVelocity = new Vector3(.05f, 0f, 0f);

    [Range(0, 1)]
    public float rangeMin;
    [Range(0, 1)]
    public float rangeMax;

    private Camera cam;
    private Plane[] planes;

    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
        planes = GeometryUtility.CalculateFrustumPlanes(cam);
    }

    // Update is called once per frame
    void Update()
    {
        // spawn a cloud maybe?
        if (sky.Count < skyMax && Random.Range(0, 100) <= spawnPercent)
        {
            SpawnCloud();
        }
        // destroy or move
        for (int i = 0; i < sky.Count; i++)
        {
            if (!GeometryUtility.TestPlanesAABB(planes, sky[i].cloudObject.GetComponent<Collider2D>().bounds))
            {
                Destroy(sky[i].cloudObject);
                sky.Remove(sky[i]);
            }
            else
            {
                sky[i].cloudObject.transform.position += sky[i].velocity;
            }
        }
    }

    private void SpawnCloud()
    {
        // new cloud, starting position, vector, and alpha
        float range = Random.Range(rangeMin, rangeMax);
        GameObject newCloud = clouds[Random.Range(0, clouds.Length)];
        Vector3 startPosition = cam.ViewportToWorldPoint(new Vector3(0f, range, -cam.transform.position.z));
        // x: changed pivot point of cloud Assets (imported pictures) to Right, that way when one is place the placement point is the extreme right of the cloud, adjust box colliders to match
        // y: random between min max (Viewport is 0-1, so it'll be placed accordingly)
        // z: since camera is offset from plane of action
        // create spawn
        GameObject spawnCloudObject = (GameObject)Instantiate(newCloud, startPosition, Quaternion.identity);
        spawnCloudObject.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, range);
        spawnCloudObject.transform.localScale = new Vector3(range, range, range);
        if (range >= .7)
            spawnCloudObject.GetComponent<SpriteRenderer>().sortingOrder = 10;
        // add to sky
        sky.Add(new Cloud(spawnCloudObject, new Vector3(baseVelocity.x * range, 0, 0)));
    }

}