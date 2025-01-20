using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public static Inventario instance;

    void Awake()
    {
        instance = this;
    }

    Renderer rd;

    //1 é sem transparencia e 0 e com trnasparencia
    float corTransparente = 1f; 

    public int velocidadeDeCaimento = 5;

    public float temporizador = 2f;

    private GirarLivro girarLivro;

    //Variavel Gameobejct para spawnar os item catalogados no inventario
    GameObject SpawnDoItemNoInventario;
    //Variavel GameObjct para spawnar os aviso catalogados no invetario com forme as suas limitacoes
    GameObject SpawnAviso;

    //Variavel dos Prefab
        //Variavel dos Livros
        public GameObject PrefablivroComum;
        public GameObject PrefablivroNoturno;
        public GameObject PrefablivroRaro;
        //Variavel dos Avisos
        public GameObject PrefabAvisoLimiteDeLivros;
    //Varival que SpawnaOobejcto no local selecionado
        //Pegando o transform dos slots para spawnar nesse local certo do invetario
        public Transform slot1;
        public Transform slot2;
        public Transform slot3;
        public Transform slot4;

    //Pegando o transform do aviso para spawnar nesse local certo do canvas
    public Transform Aviso;

    //Um armazenamento de memoria do livro pra lembrar do livro anterior
    GameObject LivroMemoria;

    //variavel para ver quantidade do mesmo livro que tem no inventario
    public int quantidadeDeLivroComum = 0;
    public int quantidadeDeLivroNoturno = 0;
    public int quantidadeDeLivroRaro = 0;

    //Variavel para verificar quantos livros atuais o jogador possui
    public int quantidadeDeLivroComumAtual = 0;
    public int quantidadeDeLivroNoturnoAtual = 0;
    public int quantidadeDeLivroRaroAtual = 0;

    //slot atual, para ver qual slot livro o player tem para poder mostrar 
    public int SlotAtual = 0;
    //slot maximo, para ver se atingio um slot maximo
    public int SlotMaximo = 5;

    //Variavel para spawnar no filho de alguem
        //spawn parentSlot no invetario
        public GameObject parentObjctSlot1;
        public GameObject parentObjctSlot2;
        public GameObject parentObjctSlot3;
        public GameObject parentObjctSlot4;
        //spawn parentAviso no SpawnAviso
        public GameObject parentAviso;

    private List<GameObject> inventario = new List<GameObject>();

    public void EntrarLivroNaLista()
    {
        if (GirarLivro.instance.numero == 0)//vai acionar se for um livroComum
        {
            if (SlotAtual <= 4)
            {
                SlotAtual++;
                quantidadeDeLivroComum++;
                quantidadeDeLivroComumAtual = quantidadeDeLivroComum;
                LivroMemoria = PrefablivroComum;
                inventario.Add(PrefablivroComum);
                ColocarNoSlotCerto();
            }
        }
        if (GirarLivro.instance.numero == 1)//vai acionar se for um livroNoturno
        {
            if (SlotAtual <= 4)
            {
                SlotAtual++;
                quantidadeDeLivroNoturno++;
                quantidadeDeLivroNoturnoAtual = quantidadeDeLivroNoturno;
                LivroMemoria = PrefablivroNoturno;
                inventario.Add(PrefablivroNoturno);
                ColocarNoSlotCerto();
            }
        }
        if (GirarLivro.instance.numero == 2)//vai acionar se for um livroRaro
        {
            if (SlotAtual <= 4)
            {
                SlotAtual++;
                quantidadeDeLivroRaro++;
                quantidadeDeLivroRaroAtual = quantidadeDeLivroRaro;
                LivroMemoria = PrefablivroRaro;
                inventario.Add(LivroMemoria);
                ColocarNoSlotCerto();
            }
        }
    }

    public void ColocarNoSlotCerto()
    {
        if(SlotAtual == 1)
        {
            SpawnDoItemNoInventario = Instantiate(LivroMemoria, slot1.transform.position, Quaternion.identity);
            SpawnDoItemNoInventario.transform.parent = parentObjctSlot1.transform;
            SpawnDoItemNoInventario.transform.localScale = new Vector3(24.3f, 32.38704f, 22.26587f);
        }
        if (SlotAtual == 2)
        {
            SpawnDoItemNoInventario = Instantiate(LivroMemoria, slot2.transform.position, Quaternion.identity);
            SpawnDoItemNoInventario.transform.parent = parentObjctSlot2.transform;
            SpawnDoItemNoInventario.transform.localScale = new Vector3(24.3f, 32.38704f, 22.26587f);
        }
        if (SlotAtual == 3)
        {
            SpawnDoItemNoInventario = Instantiate(LivroMemoria, slot3.transform.position, Quaternion.identity);
            SpawnDoItemNoInventario.transform.parent = parentObjctSlot3.transform;
            SpawnDoItemNoInventario.transform.localScale = new Vector3(24.3f, 32.38704f, 22.26587f);
        }
        if (SlotAtual == 4)
        {
            SpawnDoItemNoInventario = Instantiate(LivroMemoria, slot4.transform.position, Quaternion.identity);
            SpawnDoItemNoInventario.transform.parent = parentObjctSlot4.transform;
            SpawnDoItemNoInventario.transform.localScale = new Vector3(24.3f, 32.38704f, 22.26587f);
            girarLivro.enabled = false;
        }
        if(SlotAtual == 5)
        {
            /*
            AvisoAparecer();
            if(temporizador <= 0)
            {
                AvisoDesaparecer();
            } 

            rd = SpawnAviso.GetComponent<Renderer>();

            */
            SpawnAviso = Instantiate(PrefabAvisoLimiteDeLivros, Aviso.transform.position, Quaternion.identity);
            SpawnAviso.transform.parent = parentAviso.transform;
        }
    }

    void AvisoAparecer()
    {
        
    }

    void AvisoDesaparecer()
    {
        // Obter o material do objeto
        Material material = rd.material;

        // Modificar a cor do material
        Color color = material.color;
        color.a = corTransparente;
        material.color = color;

        if (corTransparente >= 0)
        {
            Destroy(SpawnAviso);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        girarLivro = FindObjectOfType<GirarLivro>();

        //Sempre quando iniciar vai ter sempre 0
        quantidadeDeLivroComumAtual = 0;
        quantidadeDeLivroNoturnoAtual = 0;
        quantidadeDeLivroRaroAtual = 0;

        quantidadeDeLivroComum = 0;
        quantidadeDeLivroNoturno = 0;
        quantidadeDeLivroRaro = 0;
    }

    private void Update()
    {

    }
}
