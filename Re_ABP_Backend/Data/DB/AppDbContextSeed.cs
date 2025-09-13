using Microsoft.EntityFrameworkCore;
using Re_ABP_Backend.Data.Dtos.AuthDtos;
using Re_ABP_Backend.Data.Entities;
using Re_ABP_Backend.Data.Entities.Identity;
using Re_ABP_Backend.Data.Interfraces;
using Re_ABP_Backend.Extensions;
using Serilog;
using System.Text.Json;

namespace Re_ABP_Backend.Data.DB
{
    public static class AppDbContextSeed
    {
        public static async Task SeedAsync(AppDBContext context, IUserService userService)
        {
            var triggerDir = Path.Combine(AppContext.BaseDirectory, "Data", "DB", "SQLTriggers");
            var triggersExist = await context.Database.ExecuteSqlRawAsync("SELECT COUNT(*) FROM sys.triggers") > 0;

            if (!triggersExist)
            {
                Log.Information("Start trigger creating");
                await context.ExecuteSqlScriptsFromFolderAsync(triggerDir);
            }
            else
            {
                Log.Information("Triggers already exist, skipping trigger creation.");
            }

            async Task<List<T>?> LoadJsonAsync<T>(string fileName)
            {
                var filePath = Path.Combine(AppContext.BaseDirectory, "Data", "DB", "SeedDB", fileName);
                if (!File.Exists(filePath))
                {
                    Log.Error("Seed file not found: {FilePath}", filePath);
                    return null;
                }

                var data = await File.ReadAllTextAsync(filePath);
                return JsonSerializer.Deserialize<List<T>>(data);
            }

            // Seed Genre
            if (!await context.Genre.AnyAsync())
            {
                var genres = await LoadJsonAsync<Genre>("genres.json");
                if (genres != null)
                {
                    context.Genre.AddRange(genres);
                    await context.SaveChangesAsync();
                }
            }

            // Seed BookLanguage
            if (!await context.BookLanguage.AnyAsync())
            {
                var bookLanguages = await LoadJsonAsync<BookLanguage>("bookLanguages.json");
                if (bookLanguages != null)
                {
                    context.BookLanguage.AddRange(bookLanguages);
                    await context.SaveChangesAsync();
                }
            }

            // Seed Narrator
            if (!await context.Narrator.AnyAsync())
            {
                var narrators = await LoadJsonAsync<Narrator>("narrators.json");
                if (narrators != null)
                {
                    context.Narrator.AddRange(narrators);
                    await context.SaveChangesAsync();
                }
            }

            // Seed BookSeries
            if (!await context.BookSeries.AnyAsync())
            {
                var series = await LoadJsonAsync<BookSeries>("bookseries.json");
                if (series != null)
                {
                    context.BookSeries.AddRange(series);
                    await context.SaveChangesAsync();
                }
            }

            // Seed Author
            if (!await context.Author.AnyAsync())
            {
                var authors = await LoadJsonAsync<Author>("authors.json");
                if (authors != null)
                {
                    context.Author.AddRange(authors);
                    await context.SaveChangesAsync();
                }
            }

            // Seed AudioBook
            if (!await context.AudioBook.AnyAsync())
            {
                var audiobooks = await LoadJsonAsync<AudioBook>("audiobooks.json");
                if (audiobooks != null)
                {
                    context.AudioBook.AddRange(audiobooks);
                    await context.SaveChangesAsync();
                }
            }

            // Seed AudioBookAuthor
            if (!await context.AudioBookAuthor.AnyAsync())
            {
                var abAuthors = await LoadJsonAsync<AudioBookAuthor>("audiobooks-authors.json");
                if (abAuthors != null)
                {
                    context.AudioBookAuthor.AddRange(abAuthors);
                    await context.SaveChangesAsync();
                }
            }

            // Seed AudioBookGenre
            if (!await context.AudioBookGenre.AnyAsync())
            {
                var abGenres = await LoadJsonAsync<AudioBookGenre>("audiobooks-genres.json");
                if (abGenres != null)
                {
                    context.AudioBookGenre.AddRange(abGenres);
                    await context.SaveChangesAsync();
                }
            }

            // Seed BookAudioFile
            if (!await context.BookAudioFile.AnyAsync())
            {
                var audioFiles = await LoadJsonAsync<BookAudioFile>("audioFiles.json");
                if (audioFiles != null)
                {
                    context.BookAudioFile.AddRange(audioFiles);
                    await context.SaveChangesAsync();
                }
            }

            // Seed BookSelection
            if (!await context.BookSelection.AnyAsync())
            {
                var selections = await LoadJsonAsync<BookSelection>("selections.json");
                if (selections != null)
                {
                    context.BookSelection.AddRange(selections);
                    await context.SaveChangesAsync();
                }
            }

            // Seed AudioBookSelection
            if (!await context.AudioBookSelection.AnyAsync())
            {
                var abSelections = await LoadJsonAsync<AudioBookSelection>("bookselections_books.json");
                if (abSelections != null)
                {
                    context.AudioBookSelection.AddRange(abSelections);
                    await context.SaveChangesAsync();
                }
            }

            // Seed LibraryStatus
            if (!await context.LibraryStatus.AnyAsync())
            {
                var libraryStatuses = await LoadJsonAsync<LibraryStatus>("libraryStatus.json");
                if (libraryStatuses != null)
                {
                    context.LibraryStatus.AddRange(libraryStatuses);
                    await context.SaveChangesAsync();
                }
            }

            // Seed Role
            if (!await context.Role.AnyAsync())
            {
                var roles = await LoadJsonAsync<Role>("roles.json");
                if (roles != null)
                {
                    context.Role.AddRange(roles);
                    await context.SaveChangesAsync();
                }
            }

            // Seed Users
            if (!await context.User.AnyAsync())
            {
                var usernames = new string[]
                {
                    "Taras","John","Alice","Bob","Eva","Alex","Olivia","Daniel","Sophia","William"
                };

                for (int i = 0; i < 10; i++)
                {
                    var newUser = new RegisterDto
                    {
                        Email = $"user{i + 1}@gmail.com",
                        UserName = usernames[i],
                        DateOfBirth = DateTime.Now.AddYears(-i),
                        Password = "Pa$$w0rd",
                        ConfirmPassword = "Pa$$w0rd"
                    };

                    await userService.AddUserAsync(newUser);
                }
            }

            // Seed Review
            if (!await context.Review.AnyAsync())
            {
                var reviews = await LoadJsonAsync<Review>("reviews.json");
                if (reviews != null)
                {
                    context.Review.AddRange(reviews);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
