using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    private Transform cam;
    private void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        if (Time.frameCount % 3 == 0)
        {
            transform.LookAt(transform.position + cam.forward);
        }
    }
    
    public void ChangeHP(float maxHP, float curHP)
    {
        healthBar.fillAmount = curHP / maxHP;
    }

}
