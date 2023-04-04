using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlatesCounter : BaseCounter
{
    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateRemoved;

    [SerializeField]
    private KitchenObjectSO plateKitchenObjectSo;

    private float spawnPlateTimer;
    private float spawnPlateTimerMax = 4f;
    private int platesSpawenedAmount;
    private int platesSpawnedAmountMax = 4;

    public void Update()
    {
        spawnPlateTimer += Time.deltaTime;
        if (spawnPlateTimer > spawnPlateTimerMax)
        {
            spawnPlateTimer = 0f;
            if (platesSpawenedAmount < platesSpawnedAmountMax)
            {
                platesSpawenedAmount++;

                OnPlateSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject())
        {
            if (platesSpawenedAmount > 0)
            {
                platesSpawenedAmount--;
                KitchenObject.SpawnKitchenObject(plateKitchenObjectSo, player);
                OnPlateRemoved?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
