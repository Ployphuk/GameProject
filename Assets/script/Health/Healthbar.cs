using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerrHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;

    // Start is called before the first frame update
    private void Start()
    {
        totalhealthBar.fillAmount = playerrHealth.currentHealth / 10;
    }

    // Update is called once per frame
    private void Update()
    {
        currenthealthBar.fillAmount = playerrHealth.currentHealth / 10;
    }
}
