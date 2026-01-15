using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData", order = 0)]
public class CS_Data : ScriptableObject
{
    public string PlayerName;
    public string Type;
    public int Hp;
    public int MaxHp;
    public int Attack;
    public int Level;
    public int Mp;
    public int MaxMp;
    public int Exp;
}
