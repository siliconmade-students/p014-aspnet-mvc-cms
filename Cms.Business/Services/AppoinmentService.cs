using AutoMapper;
using Cms.Business.Dtos;
using Cms.Business.Services.Abstract;
using Cms.Data;
using Cms.Data.Entity;
using Cms.SharedLibrary.Email.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Business.Services
{
	public class AppoinmentService : IAppoinmentService
	{
		private readonly AppDbContext _context;
		private readonly IMapper _mapper;
		private readonly IEmailService _mailer;

		public AppoinmentService(AppDbContext context, IMapper mapper, IEmailService mailer)
		{
			_context = context;
			_mapper = mapper;
			_mailer = mailer;
		}
		public void Create(AppoinmentDto appoinmentDto)
		{
			var items = _mapper.Map<Appoinment>(appoinmentDto);
			_context.Appoinments.Add(items);
			_context.SaveChanges(); //Daha iyi bi yöntem bulunmalı

			var appoinment = _context.Appoinments.Include(e => e.Doctor).Include(e => e.Department).OrderByDescending(e=> e.Id).First();

			_mailer.Send(appoinment.Email, "Novena Randevu Başvurunuz Onaylandı", "<h5> Sayın " + appoinment.Name + " ,</br> Hastanemizden aldığınız " + appoinment.Date + " tarihli, " + appoinment.Time + " saatli, "+appoinment.Department.Name+" departmanından, "+appoinment.Doctor.Name+ " "+ appoinment.Doctor.Surname+ " doktorumuza aldığınız randevunuz onaylanmıştır.</h5></br><h5>Mesajınız:</h5><p> " + appoinment.Content+"</p>");
		}
	}
}
