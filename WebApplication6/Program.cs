using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
builder.Configuration.AddJsonFile("book.json");
builder.Configuration.AddJsonFile("users.json");





app.Map("/", () => "Введіть значення в пошуковий рядок");
app.Map("/Library", () => "Привіт, користуваче! Гарного вам настрою при використані бібілотеки.");
app.Map("/Library/Books", async context =>
{
 
    var books = builder.Configuration.GetSection("Books").Get<List<string>>();
    context.Response.ContentType = "text/plain; charset=utf-8";
    await context.Response.WriteAsync("Список книг у бібліотеці (/Library/Books):\n");
    foreach (var book in books)
    {
        await context.Response.WriteAsync($"Назва Книги: {book}\n");
    }
});

app.Map("/Library/Profile/{id:int:range(1,5)?}", (int? id) =>
{
 var users = builder.Configuration.GetSection("Users").Get<List<User>>();
    if (id.HasValue)
{
        
    
    var user = users.FirstOrDefault(u => u.Id == id);
    return $"Інформація про користувача з ID {id}: {user.GetInfo()}";
}
else
{
        
     var user = users.FirstOrDefault(u => u.Id == -1);
     return $"Інформація про основного користувача {id}: {user.GetInfo()}";
    }
});
app.Run();
