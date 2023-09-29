using TMPro;
using UnityEngine;

public class displayFrags : MonoBehaviour
{
    public Canvas starText;
    public TextMeshProUGUI textMeshPro;
    string const_text_info;

    void Update()
    {
        const_text_info = "NUMBER OF DEFEATED ORCS: ";
        textMeshPro.text = const_text_info + enemyHealth.killed_enemies.ToString();
    }
}
