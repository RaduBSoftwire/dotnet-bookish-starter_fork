using dotnet_bookish_starter.Models;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using Microsoft.Data.SqlClient;

namespace dotnet_bookish_starter.Controllers;

[ApiController]
[Route("author")]
public class AuthorController : ControllerBase
{
    private readonly string _connectionString;
 
    public AuthorController(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("DbConnectionString") ?? "";
    }

    [HttpGet]
    public async Task<IEnumerable<Author>> Get()
    {
        using var connection = new SqlConnection(_connectionString);
        return await connection.QueryAsync<Author>("SELECT * FROM Author");
    }

    [HttpPost]
    public async Task<Author> Post([FromBody] Author author)
    {
        using var connection = new SqlConnection(_connectionString);
    
        const string sql = @"
        INSERT INTO Author (AuthorID, AuthorName)
        VALUES (@AuthorId, @AuthorName)";

        await connection.ExecuteAsync(sql, author);

        return author;
    }
    
    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] Author id)
    {

        using var connection = new SqlConnection(_connectionString);

        const string sql = "DELETE FROM Author WHERE AuthorID = @AuthorId";

        await connection.ExecuteAsync(sql, id);

        return NoContent();
    }
    
    [HttpPatch]
    public async Task<IActionResult> Patch([FromBody] Author id)
    {

        using var connection = new SqlConnection(_connectionString);

        const string sql = "DELETE FROM Author WHERE AuthorID = @AuthorId";

        await connection.ExecuteAsync(sql, id);

        return NoContent();
    }
}