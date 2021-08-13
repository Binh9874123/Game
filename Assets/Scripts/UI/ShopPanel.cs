using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] public GameLogicManager LogicManager;
    [SerializeField] public BuildingsView Builder;
    [SerializeField] private Transform _buttonParent;
    [SerializeField] private GameObject _tooltip;
    public GameObject ButtonTemplate;


    private List<BuildingProfile> _buildings;
    void Start()
    {
        _buildings = Resources.LoadAll<BuildingProfile>("Buildings/").ToList();

        foreach(var profile in _buildings)
        {
            GameObject button = Instantiate(ButtonTemplate, _buttonParent);
            button.GetComponent<ButtonHandler>().Present(profile);
            button.GetComponent<ButtonHandler>().SetBuilder(Builder);
            button.GetComponent<ButtonHandler>().SetGameLogicManager(LogicManager);
            button.GetComponent<ButtonHandler>().SetTooltip(_tooltip);
        }
    }

}
