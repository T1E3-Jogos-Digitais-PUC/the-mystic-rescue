using System;
using System.Collections.Generic;
using UnityEngine;

namespace Codigo.Scripts.shared
{
    public class ShinyRange: MonoBehaviour
    {
        public Material Material;
        public Color Color;
        public float EmissionRangeMin = 0.5f;
        public float EmissionRangeMax = 2.5f;
        public float EmissionSpeed = 1f;
        private float Intensity;
        private int IntensityLoop = 1;

        private void Start()
        {
            Intensity = EmissionRangeMin;
        }

        private void Update()
        {
            if (Material)
            {
                if (Intensity > EmissionRangeMax)
                {
                    IntensityLoop = -1;
                }
                else if (Intensity < EmissionRangeMin)
                {
                    IntensityLoop = 1;
                }

                Intensity += EmissionSpeed * Time.deltaTime * IntensityLoop;
                
                UpdateIntensityOfAMaterial(Material, Intensity);
                
            }
        }

        private void UpdateIntensityOfAMaterial(Material material, float intensity)
        {
            material.SetColor("_EmissionColor", Color * intensity);
        }
    }
}