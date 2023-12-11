using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class BeamSpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject BeamPrefab;
    GameObject BeamPlaced;

    [SerializeField]
    ARPlaneManager m_planeManager;
    void Start()
    {
        m_planeManager = GetComponent<ARPlaneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
