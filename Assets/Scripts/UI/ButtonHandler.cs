using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private string Name;
    [SerializeField] private Image Icon;
    private string Price;
    private GameObject Building = null;
    private BuildingsView _builder;
    private GameLogicManager _logicManager;
    private short _price;
    private GameObject Tooltip;
    [SerializeField] private Vector3 tooltipOffset;

    public void Present(BuildingProfile profile)
    {
        Icon.sprite = profile.Icon;
        Name = profile.Name;
        Building = profile.Building;
        _price = profile.Price;
        Price = profile.Price.ToString();

    }

    public void SetBuilder(BuildingsView _b)
    {
        _builder = _b;
    }

    public void SetBuilding()
    {
        if(_logicManager.PayMoney(_price))
        {
            _builder.StartBuildingMode(Building);
            _builder.Building = Building;
        }
    }

    public void SetGameLogicManager(GameLogicManager man)
    {
        _logicManager = man;
    }

    public void SetTooltip(GameObject tooltip)
    {
        Tooltip = tooltip;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Tooltip.GetComponent<Tooltip>().Price.text = Price;
        Tooltip.GetComponent<Tooltip>().Name.text = Name;
        TooltipSetRightPosition();
        Tooltip.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPTRExit");
        Tooltip.SetActive(false);
    }

    private void TooltipSetRightPosition()
    {
        Vector3 newPos = gameObject.transform.position + tooltipOffset;
        newPos.z = 0f;

        float rightEdgeToScreenEdgeDistance = Screen.width - (newPos.x + Tooltip.GetComponent<RectTransform>().rect.width);
        if (rightEdgeToScreenEdgeDistance < 0)
        {
            newPos.x += rightEdgeToScreenEdgeDistance;
        }

        float leftEdgeToScreenEdgeDistance = 0 - (newPos.x - Tooltip.GetComponent<RectTransform>().rect.width);
        if (leftEdgeToScreenEdgeDistance > 0)
        {
            newPos.x += leftEdgeToScreenEdgeDistance;
        }

        float topEdgeToScreenEdgeDistance = Screen.height - (newPos.y + Tooltip.GetComponent<RectTransform>().rect.height);
        if (topEdgeToScreenEdgeDistance < 0)
        {
            newPos.y += topEdgeToScreenEdgeDistance;
        }

        Tooltip.transform.position = newPos;
    }
}
