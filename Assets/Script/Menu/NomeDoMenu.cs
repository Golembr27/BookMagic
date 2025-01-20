using UnityEngine;

public class NomeDoMenu : MonoBehaviour
{
    public static NomeDoMenu instance;

    void Awake()
    {
       void Awake()
    {
        // Garante que haja apenas uma inst�ncia do NomeDoMenu
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // Destroi duplicatas
        }
    }
    }
    //Serve pra quando escrever o nome do menu nessa string vai abrir o menu que est� escrito o nome
    public int NumeroDoMenu;

    //1 = inventario
    //2= loja

}
