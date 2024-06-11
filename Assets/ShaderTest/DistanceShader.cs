using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DistanceShader : MonoBehaviour
{
    [SerializeField] private float distanceValue;
    [SerializeField] private string DissolveColorReferance;
    [SerializeField] private Color DissolveColor;
    [SerializeField] private int Intensity;
    [SerializeField] private string distanceReferance;
    [SerializeField] private string playerPosition;
    [SerializeField] private float maxDistance;
    [SerializeField] private float minmummDistance;
    private float referancevelo;
    public bool activate;
    [SerializeField] private GameObject player;
    public Volume globalVolume;
    private ChromaticAberration chromaticAberration; // Reference to the Chromatic Aberration effect
    [SerializeField] float DissolveTime;
    [SerializeField] float ReverseTime;
    private bool playingMusic;

    private void Start()
    {
        activate = false;
        playingMusic = false;
        DissolveColor *= Intensity;
        Shader.SetGlobalColor(DissolveColorReferance, DissolveColor);
        referancevelo = 0;
    }

    void Update()
    {
        changeDistance();

        if (Input.GetKeyDown(KeyCode.G))
        {
            Shader.SetGlobalVector(playerPosition, player.transform.position);
            activate = !activate;
        }
        ReveilOjects();
    }

    private void changeDistance()
    {
        Shader.SetGlobalFloat(distanceReferance, distanceValue);
    }

    public void ReveilOjects()
    {
        Shader.SetGlobalVector(playerPosition, player.transform.position);

        if (activate)
        {
            distanceValue = Mathf.SmoothDamp(distanceValue, maxDistance, ref referancevelo , DissolveTime);
            if(playingMusic == false)
            {
                ServiceLocator.Instance.GetService<AudioManager>().PlaySFX("TimeTravel");
                playingMusic = true;
            }
        }
        else
        {
           distanceValue = Mathf.SmoothDamp(distanceValue, minmummDistance, ref referancevelo, ReverseTime);
        }
    }
}
