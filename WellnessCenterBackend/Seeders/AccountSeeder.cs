﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WellnessCenterBackend.Database;
using WellnessCenterBackend.Exceptions;
using WellnessCenterBackend.Models;
using WellnessCenterBackend.Services;

namespace WellnessCenterBackend.Seeders
{
    public interface IAccountSeeder
    {
        AdminAccountDto TryCreateAdminAccount();
    }
    public class AccountSeeder : IAccountSeeder
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        private readonly IRegisterAdminService _service;

        public AccountSeeder(MyDbContext context, IMapper mapper, IRegisterAdminService service)
        {
            _context = context;
            _mapper = mapper;
            _service = service;
        }
        public AdminAccountDto TryCreateAdminAccount()
        {
            var admin = _context.Users
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Role.Name == "Admin");
            if(admin != null)
            {
                throw new ConflictException("W aplikacji może istnieć tylko jedno konto administratora!");
            }
            string password = CreateRandomPassword();

            var newAdmin = new RegisterUserDto
            {
                Login = "Administrator123",
                Password = password,
                Email = "arkadiuszschabowski@gmail.com"
            };

            var adminAccount = _mapper.Map<AdminAccountDto>(newAdmin);

            _service.RegisterAdmin(newAdmin);

            return adminAccount;
        }
        public string CreateRandomPassword()
        {
            //WaitingForUpdate
            Random rnd = new Random();
            var password = rnd.Next(1000000, 9999999).ToString();
            return password;
        }
    }
}
