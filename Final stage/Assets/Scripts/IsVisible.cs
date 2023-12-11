using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsVisible : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject SpawnManager;
    private CreateMap mapCode;

    Renderer m_Renderer;

    float timeVisible;
    public float timeScared;
    void Start()
    {
        SpawnManager = GameObject.Find("SpawnManager");
        mapCode = SpawnManager.GetComponent<CreateMap>();
        m_Renderer = GetComponent<Renderer>();

        timeVisible = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Renderer.isVisible)
        {
            timeVisible = timeVisible + Time.deltaTime;
            Debug.Log(timeVisible);
        }
        else
        {
            timeVisible = 0;
            Debug.Log("Object is not visible!");
        }

        if (timeVisible >= timeScared)
        {
            mapCode.ChangeFoundAmount(-1);
        }
    }
}
