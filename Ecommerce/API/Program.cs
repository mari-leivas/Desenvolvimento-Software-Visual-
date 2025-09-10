using API.Models;

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
app.MapGet("/", () => " API de Produtos ");

app.MapGet("/api/produto/listar",() =>
{
    return Results.Ok(produtos);
});
app.MapPost("/api/produto/cadastrar",(Produto produto) =>
{
    
   
    produtos.Add(produto);
});
app.Run();

