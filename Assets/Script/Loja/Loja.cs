using UnityEngine;
using TMPro;

public class Loja : MonoBehaviour
{
    //Para que acesse as variaveis de um outro script
    public static Loja instance;

    void Awake()
    {
        instance = this;
    }

    //Variavel que vai spawnar parete
    public GameObject SpawnDoSlot;

    //GameObejct que vai ser criado
    public GameObject SlotParaAVenda;

    //spawn do objecto primario
    public Transform SpawnSlot;

    //Vetor da posicao do objeto
    Vector3 SpawnDoObjetoInstaciado;

    public int NumeroDeSlot = 0;

    public int SlotMaximo = 0;

    public Vector3 PosicaoAtual;

    public Vector3 AlterarY;
    
    public bool PodeIrAPosicaoY = false;

    public int NumeroDeInstacias = 0;

    public TextMeshProUGUI TextoDeQuantidadeDeLivro;

    public void Slot()
    {
        NumeroDeSlot++;
    }

    public void PosicaoDeSpawn()
    {
        if (NumeroDeInstacias == NumeroDeSlot)
        {
            PosicaoAtual.y = AlterarY.y + 10f;
        }
        InstaciandoItemDaLoja();
    }

    public void LivrosAdiconados()
    {
        TextoDeQuantidadeDeLivro.text = $"{NumeroDeSlot}";
        PosicaoDeSpawn();
    }

    private void InstaciandoItemDaLoja()
    {
        NumeroDeInstacias++;
        GameObject slot = Instantiate(SlotParaAVenda, PosicaoAtual, Quaternion.identity);
        slot.transform.parent = SpawnDoSlot.transform;
        slot.transform.localScale = new Vector3(1f, 1f, 1f);
        if (NumeroDeInstacias != NumeroDeSlot)
        {
            InstaciandoItemDaLoja();
        }
    }

    private void Start()
    {
        AlterarY.y = PosicaoAtual.y;
        PosicaoAtual = SpawnSlot.transform.position;
    }
}
