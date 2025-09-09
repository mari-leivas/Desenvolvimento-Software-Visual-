using System;

namespace API.Models;

public class Produto
{
    //caracteristicas| Atributos|propiedades | preco|id |quantidade
    /*private String id;
    private String nome;

    private double preco;
    private int quantidade;

    public String getNome()
    {
        return nome;
    }
    public void setNome(String nome)
    {
        this.nome = nome;
    }*/
    public Produto()
    {
        Id = Guid.NewGuid().ToString();
        CriadoEm = DateTime.Now;
    }
    public String Id { get; set; }
    public String Nome { get; set; }
    public int Quantidade { get; set; }
    public double Preco { get; set; }
    public DateTime CriadoEm { get; set; }
    
}
    
