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

    public Vector3 PosicaoAnterior;

    public Vector3 PosicaoAnterior2;

    public float DistanciaDosElementos = 0.4f;

    public bool PodeEntra = false;

    public bool PodeEntra2 = true;

    public int NumeroDeInstacias = 0;

    public TextMeshProUGUI TextoDeQuantidadeDeLivro;

    public void Slot()
    {
        NumeroDeSlot++;
    }

    public void PosicaoDeSpawn()
    {
        PosicaoAnterior.y = PosicaoAtual.y;
        if (PodeEntra2 == true)
        {
            PosicaoAtual.y = PosicaoAnterior.y - DistanciaDosElementos;

            PodeEntra2 = false;
        }else PodeEntra = false;
       
        if(PodeEntra == false)
        {
            PodeEntra2 = true;
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
            PosicaoDeSpawn();
        }
    }

    private void Start()
    {
        PosicaoAtual = SpawnSlot.transform.position;
    }
}
