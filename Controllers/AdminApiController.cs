using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicineApi.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace MedicineApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminApiController : ControllerBase
    {
        private readonly IConfiguration _configuration;


        public AdminApiController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("addupdatemedicine")]
        public Respoce AddUpdateMedicine(Medicine medicine)
        {

            Respoce response = new Respoce();
            string connectionString = _configuration.GetConnectionString("EMedCS").ToString();
            DAL dal = new DAL();

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    response = dal.addupdateMedicine(medicine, connection);

                }
                catch (Exception ex)
                {
                    // Handle any errors that occur during the connection process.
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return response;
        }


    }
}