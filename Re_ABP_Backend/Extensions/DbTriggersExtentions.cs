using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Re_ABP_Backend.Extensions
{
    public static class DbTriggersExtentions
    {
        public static async Task ExecuteSqlScriptsFromFolderAsync(this DbContext context, string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Log.Error("SQL script folder not found: {FolderPath}", folderPath);
                return;
            }

            var sqlFiles = Directory.GetFiles(folderPath, "*.sql");

            if (sqlFiles.Length == 0)
            {
                Log.Error("No SQL scripts found in folder: {FolderPath}", folderPath);
                return;
            }

            foreach (var sqlFile in sqlFiles)
            {
                try
                {
                    var script = await File.ReadAllTextAsync(sqlFile);
                    var commands = script.Split(new[] { "GO" }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var command in commands)
                    {
                        await context.Database.ExecuteSqlRawAsync(command);
                    }

                    Log.Information("Executed SQL script: {SqlFile}", Path.GetFileName(sqlFile));
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Error executing SQL script: {SqlFile}", Path.GetFileName(sqlFile));
                }
            }
        }
    }
}