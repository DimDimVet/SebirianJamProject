using System;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Camera mCamera;
    [SerializeField] private Transform[] layers;
    [SerializeField] private float[] ratio;
    private float setZ;
    private Vector3 tempLayers;
    private void LateUpdate()
    {
        MoveRatioSprite();
        tempLayers = new Vector3();
    }
    private void MoveRatioSprite()
    {
        for (int i = 0; i < layers.Length; i++)
        {
            setZ = layers[i].position.z;
            tempLayers = mCamera.transform.position * ratio[i];

            tempLayers.z = setZ;
            layers[i].position = tempLayers;
        }
    }
}
