using TMPro;
using UnityEngine;

public class displayFrags : MonoBehaviour
{
    public Canvas starText;
    public TextMeshProUGUI textMeshPro;
    string toDisplay;

    void Update()
    {
        toDisplay = "ILOŒÆ POKONANYCH ZOMBIE: ";
        textMeshPro.text = toDisplay + enemyHealth.killed_enemies.ToString();
    }
}
