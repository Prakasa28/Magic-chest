using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AnimationObject", order = 1)]
public class AnimationObject : ScriptableObject
{
    public string[] frame1 = new string[42];
}