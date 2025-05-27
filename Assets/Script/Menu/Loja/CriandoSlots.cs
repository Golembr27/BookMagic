using UnityEngine;
using TMPro;

public class CriandoSlots : MonoBehaviour
{
    //Para que acesse as variaveis de um outro script
    public static CriandoSlots instance;

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

    public Vector3 PosicaoAnterior;

    float DistanciaDosElementos = 10f;

    public bool PodeEntra = false;

    public bool PodeEntra2 = true;

    public int NumeroDeInstacias = 0;

    bool primeiroSloot;

    public TextMeshProUGUI TextoDeQuantidadeDeLivro;

    public void Slot()
    {
        VenderLivro.Instance.AtualizacaoDeOutroScriptDarVarDosLivros();
        NumeroDeSlot++;
    }

    public void PosicaoDeSpawn()
    {
        if(primeiroSloot == true)
        {
            PosicaoAnterior.y = PosicaoAtual.y;
            if (PodeEntra2 == true)
            {
                PosicaoAtual.y = PosicaoAnterior.y - 0.5f;

                PodeEntra2 = false;
            }
            else PodeEntra = false;

            if (PodeEntra == false)
            {
                PodeEntra2 = true;
            }

            InstaciandoItemDaLoja();
        }else if (primeiroSloot == false)
        {
            primeiroSloot = true;
            InstaciandoItemDaLoja();
        }
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
        slot.transform.localScale = new Vector3(1f, 0.5f, 1f);
        if (NumeroDeInstacias != NumeroDeSlot)
        {
            PosicaoDeSpawn();
        }
    }

    private void Start()
    {
        primeiroSloot = false;
        PosicaoAtual = SpawnSlot.transform.position;
    }
}
