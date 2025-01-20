using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GirarLivro : MonoBehaviour
{
    //Para que acesse as variaveis de um outro script
    public static GirarLivro instance;

    void Awake()
    {
        instance = this;
    }

    // é a layer do spawn do livro
    SpriteRenderer sr;

    //Gameobject que spawna o livro
    GameObject SpawnLivro;

    //Variavel responsavel se o menu de spawn
    public int numeroSpawn = 0;

    //Variavel que vai spawnar os livros dentro do parent para ficar mais horganizado vizualmente.
    public GameObject SpawnParent;

    //variavel de raridade
    public int raridadeNumero = 0; 

    //Spawn do livro
    public GameObject posisaoDeSpawn;
    //O numero colocado ai vai puchar um intem da lista
    public int numero = 0;

    //Prefab dos livros
    public GameObject livroComum;
    public GameObject livroNoturno;
    public GameObject livroRaro;

    //Lista dos livros que recebe gameobject
    private List<GameObject> livro = new List<GameObject>();

    private void Start()
    {
        
    }

    //void para verificar a raridade do livro
    public void raridade()
    {
        //se a raridade for menos que 10 vai colocar na variavel numero 0 que é igual ao gameobject livro1
        if (raridadeNumero <= 10)
        {
            //quando a variavel "numero" irá receber 0 vai chama o livro1
            numero = 0;
        }
        //se a raridade for menos que 20 e maior que 10, pq nao pode ser igual a anterior se nao for maior que 10 vai ficar caindo na 10 e nunca na 20 vai colocar na variavel numero 1 que é igual ao gameobject livro2
        if (raridadeNumero <= 20 && raridadeNumero > 10)
        {
            //quando a variavel "numero" irá receber 1 vai chama o livro2
            numero = 1;
        }
        //se a raridade for menos que 30 e maior que 20, pq nao pode ser igual a anterior se nao for maior que 20 vai ficar caindo na 10 e nunca na 20 vai colocar na variavel numero 2 que é igual ao gameobject livro3
        if (raridadeNumero <= 30 && raridadeNumero > 20)
        {
            //quando a variavel "numero" irá receber 2 vai chama o livro3
            numero = 2;
        }
    }

    //Adiciona todas os livros na lista
    void Livros()
    {
        //Adicionar a variavel gameobject livro1 que é um prefab da lista
        livro.Add(livroComum);
        //Adicionar a variavel gameobject livro2 que é um prefab da lista
        livro.Add(livroNoturno);
        //Adicionar a variavel gameobject livro3 que é um prefab da lista
        livro.Add(livroRaro);
    }

    //Quando acionado vai gerer o livro
    public void Selecao()
    {
        if(Inventario.instance.SlotAtual < 4)
        {
            //um if para destruir os livro para só ficar um no centro
            if (numeroSpawn == 1)
            {
                Destroy(SpawnLivro);
                numeroSpawn--;
            }
            //Adicionar mais 1 para sempre ter só um objecto  no meio!!
            numeroSpawn++;
            //Adicionar todos os livros
            Livros();
            //Sortiar um quantida da raridade aleatoria de 0 a 30
            raridadeNumero = Random.Range(0, 30);
            //Verificar a raridade
            raridade();
            //Variavel gameobject que vai receber da lista gameobject e receber o numero aleatorio do void  raridade, que antes tirou um numero entr 0 e 30 aleatorio, assim a variavel vai "numero" seceber o numero igual a 0 ou 1 ou 2 que são os valores dos livros das listas que vai de 0, 1 ,2 ,3 etc.
            GameObject livroEscolhido = livro[numero];
            //Vai instaciar a variavel gameobject criado a cima "LivroEscolhido", irá pegar a posisaoDeSpawn e setar para a variavel spawn dar spawn nessa posicao e o ultimo eu nao lembro oq faz kk
            SpawnLivro = Instantiate(livroEscolhido, posisaoDeSpawn.transform.position, Quaternion.identity);
            
            sr = SpawnLivro.GetComponent<SpriteRenderer>();

            //Isso serve para o livro spawnar dentro do parente para os objectos na cena ficarem arrumados
            SpawnLivro.transform.parent = SpawnParent.transform;
            //colocando a layer dos livro do centro em 0 para nao ficarem em cima dos menus
            sr.sortingOrder = 0;
            
        }
    }

    
}
