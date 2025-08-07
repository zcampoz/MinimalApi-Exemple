using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using TodoApi;

var builder = WebApplication.CreateBuilder(args);

// Add Dependency Injection - AddService
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));

// Add Swagger in services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline - UseMethod
app.MapGet("/todoitems", async (TodoDb db) => await db.Todos.ToListAsync()).WithOpenApi();
app.MapGet("/todoitems/{id}", async (int id, TodoDb db) => await db.Todos.FindAsync(id)).WithOpenApi();

app.MapPost("/todoitems", async (TodoItem todo, TodoDb db) =>
{
    db.Todos.Add(todo);
    await db.SaveChangesAsync();
    return Results.Created($"/todoitems/{todo.Id}", todo);
}).WithOpenApi();

app.MapPut("/todoitems/{id}", async (int id, TodoItem inputTodo, TodoDb db) => 
{ 
    var todo = await db.Todos.FindAsync(id);
    if (todo == null) return Results.NotFound();
    todo.Name = inputTodo.Name;
    todo.IsComplete = inputTodo.IsComplete;
    await db.SaveChangesAsync();
    return Results.NoContent();
}).WithOpenApi();

app.MapDelete("/todoitems/{id}", async (int id, TodoDb db) => 
{ 
    if (await db.Todos.FindAsync(id) is TodoItem todo)
    {
        db.Todos.Remove(todo);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }
    return Results.NotFound();
}).WithOpenApi();

// Activating Swagger in Application
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
