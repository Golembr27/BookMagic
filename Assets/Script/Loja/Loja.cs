using UnityEngine;
using TMPro;

public class Loja : MonoBehaviour
{
    //Variavel que vai spawnar parete
    public GameObject SpawnDoSlot;

    //GameObejct que vai ser criado
    public GameObject SlotParaAVenda;

    //spawn do objecto primario
    public Transform SpawnSlot;

    //Vetor da posicao do objeto
    Vector3 SpawnDoObjetoInstaciado;

    public int NumeroDeSlot = 0;

    public bool PodeIrAPosicaoY = false;

    public int NumeroDeInstacias = 0;

    public Vector3 AtualY;

    public Vector3 AmazenamentoY;

    public bool SpawnPrimeiro = false;

    public TextMeshProUGUI TextoDeQuantidadeDeLivro;

    //Para que acesse as variaveis de um outro script
    public static Loja instance;

    void Awake()
    {
        instance = this;
    }
    
    public int LivroTotal = 0;

    public void Slot()
    {
        NumeroDeSlot++;
    }

    public void AdicionandoLivroTotal()
    {
        LivroTotal++;
    }

    public void PosicaoDeSpawnY()
    {
        if (SpawnPrimeiro == false)
        {
            SpawnPrimeiro = true;
            AtualY = SpawnSlot.transform.position;
        }

        if (PodeIrAPosicaoY == true){
            PodeIrAPosicaoY = false;
            AtualY.y = -20f;
        }
        else if(PodeIrAPosicaoY == false)
        {
            PodeIrAPosicaoY = true;
            AmazenamentoY = AtualY;
        }
        InstaciandoItemDaLoja();
    }

    public void LivrosAdiconados()
    {
        if (LivroTotal == NumeroDeSlot && NumeroDeSlot >= 5)
        {
            TextoDeQuantidadeDeLivro.text = $"{NumeroDeSlot}";
            PosicaoDeSpawnY(); 
        }
    }

    private void InstaciandoItemDaLoja()
    {
        NumeroDeInstacias++;
        GameObject slot = Instantiate(SlotParaAVenda, AtualY, Quaternion.identity);
        slot.transform.parent = SpawnDoSlot.transform;
        slot.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    private void Start()
    {
        SpawnPrimeiro = false;
        AtualY.y = SpawnSlot.transform.position.y;
    }
}
