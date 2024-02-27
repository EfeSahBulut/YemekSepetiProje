using MailKit.Security;
using Microsoft.AspNetCore.Identity;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSepeti.DataAccess.EntityFramework;
using YemekSepetiProje.Entities;
using YemekSepetiProje.Entitys;
using MailKit.Net.Smtp;


namespace YemekSepeti.Controllers.EntityFramework
{
    public class CustomerDal
    {
		
		public List<Customer> GetProducts()
        {
            using (YemekSepetiContext context = new YemekSepetiContext())
            {
                return context.Customers.ToList();
            }
        }

        public void Add(Customer customer)
        {
            using (YemekSepetiContext context = new YemekSepetiContext())
            {
                var entity = context.Entry(customer);
                entity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

		public void Update(Customer customer)
		{
			using (YemekSepetiContext context = new YemekSepetiContext())
			{
				var entity = context.Entry(customer);
				entity.State = EntityState.Modified;
				context.SaveChanges();
			}
		}

		public void Delete(Customer customer)
		{
			using (YemekSepetiContext context = new YemekSepetiContext())
			{
				var entity = context.Entry(customer);
				entity.State = EntityState.Deleted;
				context.SaveChanges();
			}
		}

		public Customer GetByEmail(string email)
		{
			using (YemekSepetiContext context = new YemekSepetiContext())
			{
				return context.Customers.FirstOrDefault(c => c.Email == email);
			}
		}

	
		public Customer GetByPassword(string password)
		{
			using (YemekSepetiContext context = new YemekSepetiContext())
			{
				return context.Customers.FirstOrDefault(c => c.Password == password);
			}
		}

		public List<Customer> GetByCustomerName(string key)
		{
			using (YemekSepetiContext context = new YemekSepetiContext())
			{
				return context.Customers.Where(p => p.FirstName.Contains(key.ToLower())).ToList();
			}
		}

		public bool IsEmailAlreadyExists(string email)
		{
			using (YemekSepetiContext context = new YemekSepetiContext())
			{
				return context.Customers.Any(c => c.Email == email);
			}
		}

		//private void SendEmail(string toEmail, string subject, string body)
		//{
		//	var message = new MimeMessage();
		//	message.From.Add(new MailboxAddress("Gönderen Adı", "gonderen@example.com"));
		//	message.To.Add(new MailboxAddress("Alıcı Adı", toEmail));
		//	message.Subject = subject;

		//	var bodyBuilder = new BodyBuilder();
		//	bodyBuilder.TextBody = body;

		//	message.Body = bodyBuilder.ToMessageBody();

		//	using (var client = new SmtpClient())
		//	{
		//		client.Connect("smtp.mailtrap.io", 587, SecureSocketOptions.StartTls);
		//		client.Authenticate("your-smtp-username", "your-smtp-password");

		//		client.Send(message);
		//		client.Disconnect(true);
		//	}
		//}
	}
}
