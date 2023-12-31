﻿using Bogus;
using Cms.Data.Entity;

namespace Cms.Data;

public static class DbSeeder
{
	public static void Seed(AppDbContext _db)
	{ 
	

		List<Department> departmentsCopy = new List<Department>();
		if (!_db.Departments.Any())
		{
			var departments = new List<Department>
			{
				new(){ Name="Genel Cerrahi", Description="Genel Cerrahi açıklaması",Slug="genel_cerrahi", CoverImagePath = "service-1.jpg", Content="denemeasd"},
				new(){ Name="Dahiliye", Description="Dahiliye açıklaması",Slug ="dahiliye", CoverImagePath = "service-2.jpg", Content="denemeasd"},
				new(){ Name="Göğüs cerrahisi", Description="Göğüs cerrahisi açıklaması", Slug="gogus_cerrahisi", CoverImagePath = "service-3.jpg", Content="denemeasd"},
				new(){ Name="Acil tıp", Description="Acil tıp açıklaması", Slug="acil_tip", CoverImagePath = "service-4.jpg", Content="denemeasd"},
				new(){ Name="Pediatri", Description="Pediatri açıklaması", Slug="pediatri", CoverImagePath = "service-5.jpg", Content="denemeasd"},
				new(){ Name="Jinekoloji", Description="jinekoloji açıklaması", Slug="jinekoloji", CoverImagePath = "service-6.jpg", Content="denemeasd",},
			};
			departmentsCopy = departments;
			_db.Departments.AddRange(departments);
			_db.SaveChanges();
		}

		if (!_db.Pages.Any())
		{
			_db.Pages.Add(new Page { Title = "Hakkımızda", Content = "Hakkımızda", CreatedAt = DateTime.Now, IsActive = true, Slug = "AboutUs" });
			_db.Pages.Add(new Page { Title = "İletişim", Content = "İletişim Bilgilerimiz => Tel: +90 ", CreatedAt = DateTime.Now, IsActive = true, Slug = "Contact" });
			/*
            var pageFaker = new Faker<Page>()
                .RuleFor(p => p.Title, f => f.Company.CompanyName())
                .RuleFor(p => p.Content, f => f.Lorem.Paragraphs(3))
                .RuleFor(p => p.IsActive, f => f.Random.Bool());

            var pages = pageFaker.Generate(5);
            
            _db.Pages.AddRange(pages);
            */

			_db.SaveChanges();
		}

		if (!_db.Users.Any())
		{
			var userFaker = new Faker<User>()
				.RuleFor(u => u.Email, f => f.Internet.Email())
				.RuleFor(u => u.Password, f => f.Internet.Password())
				.RuleFor(u => u.Name, f => f.Person.FirstName)
				.RuleFor(u => u.Surname, f => f.Person.LastName)
				.RuleFor(u => u.City, f => f.Address.City())
				.RuleFor(u => u.Phone, f => f.Phone.PhoneNumber("###-###-####"));

			var users = userFaker.Generate(10);
			users.Add(new User() { Name = "Admin", Email = "admin@gmail.com", Password = "admin", Roles = "Admin", Surname = "Admin", Phone = "00000000", City = "Ankara" });
			_db.Users.AddRange(users);
			_db.SaveChanges();
		}

		int postCount = 55;

		if (!_db.PostImages.Any())
		{
			var imgPaths = new string[] { "blog-1.jpg", "blog-2.jpg", "blog-6.jpg", "blog-4.jpg", "blog-7.jpg", "blog-8.jpg", "testimonial1.jpg", "testimonial2.jpg", };
			var postImageFaker = new Faker<PostImage>()
				.RuleFor(pi => pi.ImagePath, f => f.PickRandom<string>(imgPaths));

			_db.PostImages.AddRange(postImageFaker.Generate(postCount));
			_db.SaveChanges();
		}

		if (!_db.Posts.Any())
		{
			var users = _db.Users.ToList();

			var postFaker = new Faker<Post>()
				.RuleFor(p => p.Title, f => f.Lorem.Sentence())
				.RuleFor(p => p.Content, f => f.Lorem.Paragraphs(5))
				.RuleFor(p => p.User, f => f.PickRandom(users))
				.RuleFor(p => p.Departments, f => f.PickRandom(_db.Departments.ToList(), f.Random.Number(1, 2)).ToList());

			var posts = postFaker.Generate(postCount);

			for (int i = postCount; i > 0; i--)
			{
				posts[i - 1].PostImageId = i;
			}

			_db.Posts.AddRange(posts);
			_db.SaveChanges();
		}

		if (!_db.PostComments.Any())
		{
			var postCommentFaker = new Faker<PostComment>()
				.RuleFor(pc => pc.PostId, f => f.Random.Number(1, postCount))
				.RuleFor(pc => pc.UserId, f => f.Random.Number(1, 10))
				.RuleFor(pc => pc.Comment, f => f.Lorem.Sentence())
				.RuleFor(pc => pc.IsActive, f => f.Random.Bool());

			var postComments = postCommentFaker.Generate(postCount * 3);

			_db.PostComments.AddRange(postComments);
			_db.SaveChanges();
		}

		if (!_db.Settings.Any())
		{
			/*
			var settingFaker = new Faker<Setting>()
				.RuleFor(s => s.UserId, f => f.Random.Number(1, 10))
				.RuleFor(s => s.Name, f => f.Lorem.Word())
				.RuleFor(s => s.Value, f => f.Lorem.Sentence());

			var settings = settingFaker.Generate(10);
			*/
			List<Setting> settings = new List<Setting>()
			{
				new(){ Name="Telefon", Value="+90 123 456 7891"},
				new(){ Name="Email", Value="hastane@novena.com"},
				new(){ Name="CalismaGunSaat", Value="Pzt-Cm : Tatil, Cmt-Pz : Tatil"}
			};
			_db.Settings.AddRange(settings);
			_db.SaveChanges();
		}

		if (!_db.Doctors.Any())
		{
			var imgPaths = new string[] { "1.jpg", "2.jpg", "3.jpg", "4.jpg", "test-thumb1.jpg", "test-thumb2.jpg", "test-thumb3.jpg", "test-thumb4.jpg", };

			var doctorFaker = new Faker<Doctor>()
				.RuleFor(s => s.Name, f => f.Name.FirstName())
				.RuleFor(s => s.Surname, f => f.Name.LastName())
				.RuleFor(s => s.DepartmentId, f => f.Random.Int(1, departmentsCopy.Count()))
				.RuleFor(s => s.ImagePath, f => f.PickRandom<string>(imgPaths))
				.RuleFor(s => s.Content, f => f.Lorem.Text());

			var doctors = doctorFaker.Generate(10);

			_db.Doctors.AddRange(doctors);
			_db.SaveChanges();
		}
	}
}
