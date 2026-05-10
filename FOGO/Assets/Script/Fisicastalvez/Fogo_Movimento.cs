using Unity.VectorGraphics;
using UnityEngine;

public class Fogo_Movimento : MonoBehaviour
{
    public ParticleSystem Fogo;
    public Script_Player playerScripRef;
    private Vector3 playerMov;
    public float Influence = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  
    // Update is called once per frame
    void Update()
    {
        var VelocityOvLf = Fogo.velocityOverLifetime;
        playerMov = playerScripRef.movRef;
        VelocityOvLf.x = -playerMov.x * Influence;
        VelocityOvLf.z = -playerMov.z * Influence;

    }
}
