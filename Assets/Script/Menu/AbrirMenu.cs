using System.Collections.Generic;
using UnityEngine;

public class AbrirMenu : MonoBehaviour
{

    public int NumeroDoMenu;

    //Variavel serve para poder desativar o menu
    public bool podeAtivarOMenu = true;

    //Menus para ser ativador ou desativado
    public GameObject inventario;
    public GameObject loja;

    //Serve para receber o menu para ativar e desativar o menu
    GameObject menuSelecionado;


    private void MenuSelecionado()
    {
        if (podeAtivarOMenu == true)
        { 
            podeAtivarOMenu = false;
            if (NumeroDoMenu == 1)
            {
                menuSelecionado = inventario;
                AparecerMenu();
            }
            if (NumeroDoMenu == 2)
            {
                menuSelecionado = loja;
                AparecerMenu();
            }
        }
    }

    public void Inventario()
    {
        NumeroDoMenu = 1;
        MenuSelecionado();
    }

    public void Loja()
    {
        NumeroDoMenu = 2;
        MenuSelecionado();
    }

    public void AparecerMenu()
    {
        menuSelecionado.SetActive(true);
    }

    public void DesativarMenu()
    {
        menuSelecionado.SetActive(false);
        podeAtivarOMenu = true;
    }

    private void Start()
    {
        podeAtivarOMenu = true;
    }
}