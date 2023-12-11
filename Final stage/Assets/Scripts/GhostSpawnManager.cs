using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class GhostSpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] 
    GameObject spawnablePrefab;
    public List<GameObject> spawnedObjects = new List<GameObject>();
    Vector3 spawnPosition;
    public float restrictionX;
    public float restrictionY;
    public float restrictionZ;
    public float detectionSphereRadius;

    public int spawnLimit;
    int spawnAmount;
    bool firstSpawn;
    bool deleted;
    public float spawnTime;
    float time_remaining;
    float runningTime;

    Vector3 cameraPosition;
    void Start()
    {
        spawnAmount = 0;
        firstSpawn = false;
        deleted = false;

        time_remaining = spawnTime;
        runningTime = 0;

        cameraPosition = transform.position;
        //cameraPosition = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       //cameraPosition = Camera.main.transform.position;
       cameraPosition = transform.position;
       runningTime = runningTime + Time.deltaTime;

       if(time_remaining > 0)
       {
            time_remaining = time_remaining - Time.deltaTime;
       }
       else
       {
            if(spawnAmount > spawnLimit)
            {
                spawnAmount = 0;
                firstSpawn = true;
            }
            if(!firstSpawn)
            {
                spawnPosition = new Vector3(Random.Range(cameraPosition.x - restrictionX, cameraPosition.x + restrictionX), Random.Range(cameraPosition.y, cameraPosition.y + restrictionY), Random.Range(cameraPosition.z - restrictionZ, cameraPosition.z + restrictionZ));
                spawnedObjects.Add(Instantiate(spawnablePrefab, spawnPosition, Quaternion.identity));
                if (Physics.CheckSphere(cameraPosition, detectionSphereRadius))
                {
                    Destroy(spawnedObjects[spawnAmount]);
                    spawnedObjects.RemoveAt(spawnAmount);
                    goto continueProcess;
                }
            }
            else
            {
                if(!deleted)
                {
                    Destroy(spawnedObjects[spawnAmount]);
                    spawnedObjects.RemoveAt(spawnAmount);

                    deleted = true;
                }

                spawnPosition = new Vector3(Random.Range(cameraPosition.x - restrictionX, cameraPosition.x + restrictionX), Random.Range(cameraPosition.y, cameraPosition.y + restrictionY), Random.Range(cameraPosition.z - restrictionZ, cameraPosition.z + restrictionZ));
                spawnedObjects.Insert(spawnAmount, Instantiate(spawnablePrefab, spawnPosition, Quaternion.identity));
                if (Physics.CheckSphere(cameraPosition, detectionSphereRadius))
                {
                    Destroy(spawnedObjects[spawnAmount]);
                    spawnedObjects.RemoveAt(spawnAmount);
                    goto continueProcess;
                }
            }

            deleted = false;
            spawnAmount++;
            time_remaining = spawnTime;
       }

    continueProcess:;
    }

}
