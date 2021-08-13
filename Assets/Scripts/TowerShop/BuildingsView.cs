using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuildingsView : MonoBehaviour
{
    private RaycastHit Hit;
    public GameObject Building;
    [SerializeField] private GameObject BuildingBlueprint;
    private GameObject _battleManager;
    private GameObject buildingViewer;
    private bool _buildingMode = false;

    private void Start()
    {
        _battleManager = GameObject.Find("BattleManager");
    }

    public void StartBuildingMode(GameObject buildingTemplate)
    {
        Vector3 hitpoint = Vector3.zero;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out Hit, 5000f, 1 << 8))
        {
            hitpoint = Hit.point;
        }

        _buildingMode = true;
        Building = buildingTemplate;
        buildingViewer = Instantiate(BuildingBlueprint, hitpoint, transform.rotation);        
    }

    public void EndBuildingMode()
    {
        _buildingMode = false;
    }


    private void Update()
    {
        if(_buildingMode)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out Hit, 5000f, (1<<8)))
            {
                Vector3 temp = Hit.point;
                
                buildingViewer.transform.position = temp;
            }

            if (Input.GetMouseButtonDown(0))
            {
                GameObject newTower = Instantiate(Building, buildingViewer.transform.position, buildingViewer.transform.rotation);
                _battleManager.GetComponent<BattleManager>().CreateTower(newTower);
                Destroy(buildingViewer);
                EndBuildingMode();
            }

            if (Input.GetMouseButtonDown(1))
            {
                Destroy(buildingViewer);
                EndBuildingMode();
            }
        }       

    }

}
