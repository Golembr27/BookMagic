using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VenderLivro : MonoBehaviour
{
    public static VenderLivro Instance;

    private void Awake()
    {
        Instance = this;
    }

    public TextMeshProUGUI TextoDinheiro;

    public int LivroSelecionado;

    public float ValorDoLivroVendido;

    public int MercadoItem;

    public float DemandaDoLivro = 0;

    //Raridade do livro no mercado
    public float RaroAtualDoMercado;
    public float ComumAtualDoMercado;
    public float NoturnoAtualDoMercado;

    //Quantidade de livros no mercado
    public int QuatidadeDeLivroRaroDoMercado;
    public int QuantidadeDeLivroComumDoMercado;
    public int QuantidadeDeLivroNoturnoDoMercado;

    public int RaroAtual;
    public int ComumAtual;
    public int NoturnoAtual;

    public int RaroAtualMemoria;
    public int ComumAtualMemoria;
    public int NoturnoAtualMemoria;

    public bool MemoriaAtiva = false;


    public void AtualizacaoDeOutroScriptDarVarDosLivros()
    {
        RaroAtual = Inventario.instance.quantidadeDeLivroRaroAtual;
        ComumAtual = Inventario.instance.quantidadeDeLivroComumAtual;
        NoturnoAtual = Inventario.instance.quantidadeDeLivroNoturnoAtual;
    }

    public void AtualizacaoDeLivro()
    {
        RaroAtual = Inventario.instance.quantidadeDeLivroRaroAtual;
        ComumAtual = Inventario.instance.quantidadeDeLivroComumAtual;
        NoturnoAtual = Inventario.instance.quantidadeDeLivroNoturnoAtual;
        ValorLivro();
    }

    public void ValorLivro()
    {
        if(RaroAtual >= 1)
        {
            LivroSelecionado = QuatidadeDeLivroRaroDoMercado;
            VerificarInflacao();
        }
        if (ComumAtual >= 1)
        {
            LivroSelecionado = QuantidadeDeLivroComumDoMercado;
            VerificarInflacao();
        }
        if (NoturnoAtual >= 1)
        {
            LivroSelecionado = QuantidadeDeLivroNoturnoDoMercado;
            VerificarInflacao();
        }
    }

    public void VerificarInflacao()
    {
        if(QuatidadeDeLivroRaroDoMercado < DemandaDoLivro)
        {
            ValorDoLivroVendido = QuatidadeDeLivroRaroDoMercado * RaroAtualDoMercado;
            TextoMuda();
        }
    }

    public void TextoMuda()
    {
        TextoDinheiro.text = $"{ValorDoLivroVendido}";
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RaroAtualDoMercado = Random.Range(0.5f, 10f);
        ComumAtualDoMercado = Random.Range(0.5f, 10f);
        NoturnoAtualDoMercado = Random.Range(0.5f, 10f);

        Debug.Log($"{NoturnoAtualDoMercado}, {ComumAtualDoMercado}, {RaroAtualDoMercado}");
    }

}
