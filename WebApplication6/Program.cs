using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
builder.Configuration.AddJsonFile("book.json");
builder.Configuration.AddJsonFile("users.json");





app.Map("/", () => "������ �������� � ��������� �����");
app.Map("/Library", () => "�����, �����������! ������� ��� ������� ��� ���������� ��������.");
app.Map("/Library/Books", async context =>
{
 
    var books = builder.Configuration.GetSection("Books").Get<List<string>>();
    context.Response.ContentType = "text/plain; charset=utf-8";
    await context.Response.WriteAsync("������ ���� � �������� (/Library/Books):\n");
    foreach (var book in books)
    {
        await context.Response.WriteAsync($"����� �����: {book}\n");
    }
});

app.Map("/Library/Profile/{id:int:range(1,5)?}", (int? id) =>
{
 var users = builder.Configuration.GetSection("Users").Get<List<User>>();
    if (id.HasValue)
{
        
    
    var user = users.FirstOrDefault(u => u.Id == id);
    return $"���������� ��� ����������� � ID {id}: {user.GetInfo()}";
}
else
{
        
     var user = users.FirstOrDefault(u => u.Id == -1);
     return $"���������� ��� ��������� ����������� {id}: {user.GetInfo()}";
    }
});
app.Run();
