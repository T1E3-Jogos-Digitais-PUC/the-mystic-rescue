using UnityEngine;
using UnityEngine.UIElements;
using Random = System.Random;

namespace Codigo.Scripts
{
    public class GameHelper
    {
        public static int GetRandomInt(int min, int max)
        {
            return new Random().Next(min, max);
        }
        
        public static float GetRandomFloat(float min, float max)
        {
            return (float) new Random().NextDouble() * (max - min) + min;
        }
    }
}