using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SampleSceneController : MonoBehaviour
{
    public GameObject SpawnPosition;
    public GameObject toSpawn;
    public TextMeshProUGUI text_c;
    public string timerData;
    
    private GameObject spawned;

    public string LoadObject;
    void Start()
    {
        Settings cube_s = (Settings)Resources.Load(LoadObject);
        
        spawned = Instantiate(cube_s.GetMesh(), SpawnPosition.transform.position, SpawnPosition.transform.rotation);
        spawned.name = cube_s.getName();

        TimerSettings timer_s = (TimerSettings)Resources.Load(timerData);
        spawned.GetComponent<GeometryObjectModel>().SetTimer(timer_s.GetTimer());
    }
    private void Update()
    {
        text_c.text = string.Empty + spawned.GetComponent<GeometryObjectModel>().getClicksCount();
    }

}
