using TMPro;
using UnityEngine;

public class displayFrags : MonoBehaviour
{
    public Canvas starText;
    public TextMeshProUGUI textMeshPro;
    string toDisplay;

    void Update()
    {
        toDisplay = "ILO�� POKONANYCH ZOMBIE: ";
        textMeshPro.text = toDisplay + enemyHealth.killed_enemies.ToString();
    }
}
