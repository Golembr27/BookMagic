using UnityEngine;

public class PermitirAbrirMenu : MonoBehaviour
{
    public static PermitirAbrirMenu instance;

    void Awake()
    {
        instance = this;
    }

    public bool Permição = false;
    public int MenuMaximo = 0;
    public int MenuAtual = 0;
}
