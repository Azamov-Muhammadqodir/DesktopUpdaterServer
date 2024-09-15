using AvaloniaAppUpdaterServer.Data.Db;
using Microsoft.EntityFrameworkCore;

namespace AvaloniaAppUpdaterServer.Data;

public class FileService
{
    private readonly AppDbContext _dbContext;

    public FileService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task RemoveAll()
    {
        _dbContext.Database.ExecuteSqlRaw("TRUNCATE TABLE public.\"AppFiles\";");
        return Task.CompletedTask;
    }


    public async Task<List<AppFile>> GetAllFile()
    {
        return await _dbContext.AppFiles.ToListAsync<AppFile>();
    }

    public async Task SaveFileAsync(string version, byte[] fileData)
    {
        var file = new AppFile
        {
            Version = version,
            FileData = fileData,
        };
        var res = _dbContext.AppFiles.Add(file);
        await _dbContext.SaveChangesAsync();
    }
    public async Task<string?> GetVersionAsync()
    {
        var result = _dbContext.AppFiles.OrderByDescending(x=>x.Id).Select(x=>x.Version).FirstOrDefault();
        return result is not null 
            ? result 
            : null;
    }
    public async Task<AppFile?> GetFileAsync()
    {
        var result = _dbContext.AppFiles.OrderByDescending(x => x.Id).FirstOrDefault();
        return result is not null
            ? result
            : null;
    }
}
public class AppFile
{
    public int Id { get; set; }
    public string Version { get; set; }
    public byte[] FileData { get; set; }
}

