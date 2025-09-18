using API.Models;
using Microsoft.AspNetCore.Mvc;

Console.Clear();
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
 List<Produto> produtos = new List<Produto>
        {
            new Produto { Nome = "Notebook", Quantidade = 10, Preco = 3500.00 },
            new Produto { Nome = "Smartphone", Quantidade = 20, Preco = 2200.00 },
            new Produto { Nome = "Headset Gamer", Quantidade = 15, Preco = 350.00 },
            new Produto { Nome = "Monitor 24\"", Quantidade = 8, Preco = 900.00 },
            new Produto { Nome = "Teclado Mecânico", Quantidade = 12, Preco = 450.00 }
};

//Funcionalidades
//Requisições
// - Endereço/URL
// - Método HTTP
// Métodos HTTP 
// GET: BUSCAR DADOS DE UM SERVIDOR SEM MODIFICAR O RECURSO.
// POST: ENVIAR DADOS PARA UM SERVIDOR PARA CRIAR UM NOVO RECURSO.
// PUT: ATUALIZAR UM RECURSO EXISTENTE NO SERVIDOR.
// DELETE: REMOVER UM RECURSO DO SERVIDOR.


app.MapGet("/", () => " API de Produtos ");
app.MapGet("/api/produto/listar",() =>
{
// VALIDAR SE EXISTE ALGUMA COISA DENTRO DA LISTA 
    if (produtos.Count > 0)
    {
        return Results.Ok(produtos);
    }
        return Results.BadRequest("lista vazia");
    
});
app.MapPost("/api/produto/cadastrar", ([FromBody] Produto produto) =>
{
    foreach (Produto produtoCadastrado in produtos)
    {
        if (produtoCadastrado.Nome == produto.Nome)
        {
            return Results.Conflict("Produto já cadastrado");
        }
    }

    produtos.Add(produto);
    return Results.Created("", produto);
});
app.MapGet("/api/produto/buscar", ([FromRoute] String nome) =>
{
    //exprexao lambda
    // produto produto =produtos.FirstOrDefault( p => p.Nome == nome);
    Produto? resultado = produtos.FirstOrDefault(p => p.Nome == nome);
    if (resultado == null)
    {
        return Results.NotFound("Produto não encontrado");
    }
    return Results.Ok(resultado);
});
app.Run();

