using UnityEngine;

[CreateAssetMenu(fileName = "PlayerControlAsset", menuName = "Scriptable Objects/PlayerControlAsset")]
public class PlayerControlAsset : ScriptableObject
{
    public KeyCode forward;
    public KeyCode backward;
    public KeyCode left;
    public KeyCode right;
}
