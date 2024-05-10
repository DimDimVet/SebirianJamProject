using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float smesh;
    [SerializeField] private Camera mCamera;
    [SerializeField] private Transform[] layers;
    [SerializeField] private float[] ratio;
    private Vector3[] compensPositionLayers;
    private float setZ;
    private Vector3 tempLayers;
    private void Start()
    {
        compensPositionLayers = new Vector3[layers.Length];
        for (int i = 0; i < layers.Length; i++)
        {
            compensPositionLayers[i] = layers[i].position;
        }
    }
    private void LateUpdate()
    {
        MoveRatioSprite();
        tempLayers = new Vector3();
    }
    private void MoveRatioSprite()
    {
        Vector3 vector3 = new Vector3();
        vector3.x = smesh;
        for (int i = 0; i < layers.Length; i++)
        {
            setZ = layers[i].position.z;
            
            tempLayers = (mCamera.transform.position + compensPositionLayers[i]+ vector3) * ratio[i]; 

            tempLayers.z = setZ;
            layers[i].position = tempLayers;
        }
    }
}
