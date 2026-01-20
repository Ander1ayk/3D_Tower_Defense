using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;
    [Header("Path")]
    public Transform[] pathPoints;
    public Transform startPoint;
    
    private void Awake()
    {
        main = this;
    }

}
