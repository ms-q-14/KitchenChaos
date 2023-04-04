using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounterVisual : MonoBehaviour
{
    [SerializeField]
    private PlatesCounter platesCounter;

    [SerializeField]
    private Transform counterTopPoint;

    [SerializeField]
    private Transform plateVisualPrefab;

    private List<GameObject> plateVisualGameObjectList;

    private void Awake()
    {
        plateVisualGameObjectList = new List<GameObject>();
    }

    private void Start()
    {
        platesCounter.OnPlateSpawned += PlatesCounter_OnPlateSpawned;
        platesCounter.OnPlateRemoved += PlatesCounter_OnPlateRemoved;
    }

    private void PlatesCounter_OnPlateRemoved(object sender, System.EventArgs e)
    {
        GameObject plateVisualGameObject = plateVisualGameObjectList[
            plateVisualGameObjectList.Count - 1
        ];
        plateVisualGameObjectList.Remove(plateVisualGameObject);
        Destroy(plateVisualGameObject);
    }

    private void PlatesCounter_OnPlateSpawned(object sender, System.EventArgs e)
    {
        Transform plateVisualTransfrom = Instantiate(plateVisualPrefab, counterTopPoint);

        float plateOffsetY = 0.1f;

        plateVisualTransfrom.localPosition = new Vector3(
            0f,
            plateOffsetY * plateVisualGameObjectList.Count,
            0f
        );

        plateVisualGameObjectList.Add(plateVisualTransfrom.gameObject);
    }
}
