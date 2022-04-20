using UnityEngine;

[System.Serializable]
public class RangeFloat
{
    private float min;
    private float max;
    private float currentValue;
    public RangeFloat(float min, float max)
    {
        this.min = min;
        this.max = max;
        this.currentValue = min;
    }

    public float Current { 
        get { 
            return currentValue; 
        } 
    }

    public void Add(float value)
    {
        currentValue = Mathf.Clamp(currentValue + value, min, max);
    }

    public void Sub(float value)
    {
        currentValue = Mathf.Clamp(currentValue - value, min, max);
    }

    
}
