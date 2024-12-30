using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ore", menuName = "Ore")]
public class OreData : ScriptableObject
{
    [Header("Ore Stats")]
    [SerializeField] private string _oreName;
    [SerializeField] private string _oreDescription;
    [SerializeField] private int _hitsToDestroy;
    [SerializeField] private int _sellPrice;

    [Header("Ore Visuals")]
    [SerializeField] private Sprite _oreSprite;

    public string Name
    {
        get { return _oreName; }
        set { _oreName = value; }
    }

    public string Description
    {
        get { return _oreDescription; }
        set { _oreDescription = value; }
    }

    public int HitsToDestroy
    {
        get { return _hitsToDestroy; }
        set { _hitsToDestroy = value; }
    }

    public int Price
    {
        get { return _sellPrice; }
        set { _sellPrice = value; }
    }

    public Sprite Sprite
    {
        get { return _oreSprite; }
        set { _oreSprite = value; }
    }
}
