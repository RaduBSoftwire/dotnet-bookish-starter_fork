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
    public async Task<IActionResult> Post([FromBody] Author author)
    {
        using var connection = new SqlConnection(_connectionString);
    
        const string sql = @"
        INSERT INTO Author (AuthorID, AuthorName)
        VALUES (@AuthorId, @AuthorName)";

        await connection.ExecuteAsync(sql, author);

        return Ok($"AuthorName: {author.AuthorName} | AuthorID: {author.AuthorID}");
    }
    
    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] long authorId)
    {
        using var connection = new SqlConnection(_connectionString);

        const string sql = "DELETE FROM Author WHERE AuthorID = @AuthorId";

        await connection.ExecuteAsync(sql, new { AuthorId = authorId });

        return Ok($"Deleted AuthorID: {authorId}");
    }

    [HttpPatch]
    public async Task<IActionResult> Patch([FromBody] Author author)
    {
        using var connection = new SqlConnection(_connectionString);

        const string sql = "UPDATE Author SET AuthorName = @AuthorName WHERE AuthorID = @AuthorId";

        await connection.ExecuteAsync(sql, author);

        return Ok($"New AuthorName: {author.AuthorName} | AuthorID: {author.AuthorID}");
    }
}
