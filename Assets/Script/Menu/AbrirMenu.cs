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


    /*
    RectTransform RT;

    public string NomeDoMenuAAbrir = "";

    public GameObject ParenteDoMenuASpawnar;

    string AnteriorNomeDoMenuAAbrir;

    public GameObject spawnMenu;

    public GameObject PrefabDoMenu;

    GameObject Menu;

    private void Start()
    {
        RT = Menu.GetComponent<RectTransform>();
    }

    public void SelecionarMenu()
    {
        if(NomeDoMenuAAbrir == "Loja")
        {
            if(AnteriorNomeDoMenuAAbrir == "Inventario" && PermitirAbrirMenu.instance.Permição == false)
            {
                Destroy(Menu);
                PermitirAbrirMenu.instance.Permição = true;
                NomeDoMenuAAbrir = AnteriorNomeDoMenuAAbrir;
                SelecionarMenu();
            }
            if(NomeDoMenuAAbrir == "Loja" && PermitirAbrirMenu.instance.Permição == true)
            {
                AnteriorNomeDoMenuAAbrir = NomeDoMenuAAbrir;
                Menu = Instantiate(PrefabDoMenu, spawnMenu.transform.position, Quaternion.identity);
                Menu.transform.parent = ParenteDoMenuASpawnar.transform;
                Menu.transform.localScale = new Vector3(0.97f, 0.97f, 0.97f);
                PermitirAbrirMenu.instance.Permição = false;
            }
        }
        if(NomeDoMenuAAbrir == "Inventario")
        {
            Menu = Instantiate(PrefabDoMenu, spawnMenu.transform.position, Quaternion.identity);
        }
    }

    public void ExpluirMenu()
    {
        PermitirAbrirMenu.instance.Permição = true;
    }
    */
}