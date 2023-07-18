using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Cms.Data.Entity;

namespace Cms.Data.Utility;

public static class DbSeeder
{
    public static void Seed(AppDbContext _db)
    {
        if (!_db.Categories.Any())
        {
            var categoryFaker = new Faker<Category>()
                .RuleFor(c => c.Name, f => f.Commerce.Categories(1)[0])
                .RuleFor(c => c.Description, f => f.Lorem.Sentence());

            var categories = categoryFaker.Generate(10);

            _db.Categories.AddRange(categories);
            _db.SaveChanges();
        }

        if (!_db.Pages.Any())
        {
            var pageFaker = new Faker<Page>()
                .RuleFor(p => p.Title, f => f.Company.CompanyName())
                .RuleFor(p => p.Content, f => f.Lorem.Paragraphs(3))
                .RuleFor(p => p.IsActive, f => f.Random.Bool());

            var pages = pageFaker.Generate(5);

            _db.Pages.AddRange(pages);
            _db.SaveChanges();
        }

        if (!_db.Users.Any())
        {
            var userFaker = new Faker<User>()
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.Password, f => f.Internet.Password())
                .RuleFor(u => u.Name, f => f.Person.FullName)
                .RuleFor(u => u.City, f => f.Address.City())
                .RuleFor(u => u.Phone, f => f.Phone.PhoneNumber("###-###-####"));

            var users = userFaker.Generate(10);

            _db.Users.AddRange(users);
            _db.SaveChanges();
        }

        if (!_db.Posts.Any())
        {
            var postFaker = new Faker<Post>()
                .RuleFor(p => p.Title, f => f.Lorem.Sentence())
                .RuleFor(p => p.Content, f => f.Lorem.Paragraphs(5))
                .RuleFor(p => p.UserId, f => f.Random.Number(1, 10))
                .RuleFor(p => p.Categories, f => f.PickRandom(_db.Categories.ToList(), f.Random.Number(1, 3)).ToList());

            var posts = postFaker.Generate(10);

            _db.Posts.AddRange(posts);
            _db.SaveChanges();
        }

        if (!_db.PostComments.Any())
        {
            var postCommentFaker = new Faker<PostComment>()
                .RuleFor(pc => pc.PostId, f => f.Random.Number(1, 10))
                .RuleFor(pc => pc.UserId, f => f.Random.Number(1, 10))
                .RuleFor(pc => pc.Comment, f => f.Lorem.Sentence())
                .RuleFor(pc => pc.IsActive, f => f.Random.Bool());

            var postComments = postCommentFaker.Generate(10);

            _db.PostComments.AddRange(postComments);
            _db.SaveChanges();
        }

        if (!_db.PostImages.Any())
        {
            var postImageFaker = new Faker<PostImage>()
                .RuleFor(pi => pi.PostId, f => f.Random.Number(1, 10))
                .RuleFor(pi => pi.ImagePath, f => f.Image.PicsumUrl());

            var postImages = postImageFaker.Generate(10);

            _db.PostImages.AddRange(postImages);
            _db.SaveChanges();
        }

        if (!_db.Settings.Any())
        {
            var settingFaker = new Faker<Setting>()
                .RuleFor(s => s.UserId, f => f.Random.Number(1, 10))
                .RuleFor(s => s.Name, f => f.Lorem.Word())
                .RuleFor(s => s.Value, f => f.Lorem.Sentence());

            var settings = settingFaker.Generate(10);

            _db.Settings.AddRange(settings);
            _db.SaveChanges();
        }
    }
}
