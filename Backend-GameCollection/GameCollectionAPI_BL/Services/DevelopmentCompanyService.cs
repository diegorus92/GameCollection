using GameCollectionAPI_BL.DTOs;
using GameCollectionAPI_DAL.Data;
using GameCollectionAPI_DAL.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
//using System.Data.Entity;

namespace GameCollectionAPI_BL.Services
{
    public class DevelopmentCompanyService:IDevelopmentCompanyService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly string _imagePath;

        public DevelopmentCompanyService(DatabaseContext databaseContext, IConfiguration config)
        {
            _databaseContext = databaseContext;
            _imagePath = config.GetSection("Configuration").GetSection("ImagePath").Value;
        }

        public string AddCompany(DevelopmentCompanyDTO company)
        {
            DevelopmentCompany? myCompany = _databaseContext.DevelopmentCompanies.FirstOrDefault(devCompany => devCompany.DevelopmentCompanyName.ToLower() == company.DevelopmentCompanyName.ToLower());
            if (myCompany != null) return $"Company -<{company.DevelopmentCompanyName}>- already exist";
            string status = "";

            //Saving Logo image of Company
            //It will be saved into "...Assets>Images" folder
            string logoPath = "";
            string imageExtension = company.File.FileName.Split(".")[1];

            if (imageExtension != "jpg" && imageExtension != "png") 
                return $"Image extension not supported!, only -jpg- o -png-";
            
            try
            {
                logoPath = Path.Combine(_imagePath, (company.LogoName+"."+imageExtension));
                using (Stream fileStream = new FileStream(logoPath, FileMode.Create))
                {
                    company.File.CopyTo(fileStream);
                }

                status += $"Image saved successfully into {logoPath}\n";
            }
            catch(Exception ex) 
            {
                status += $"Error while saving logo: {ex.Message}\n";
            }
            
            myCompany = new DevelopmentCompany(company.DevelopmentCompanyName,logoPath);
            _databaseContext.DevelopmentCompanies.Add(myCompany);
            _databaseContext.SaveChanges();
            _databaseContext.Dispose();
            status += $"Development Company ID:{myCompany.DevelopmentCompanyId} -<{myCompany.DevelopmentCompanyName}>- saved successfully!";
            return status ;
        }

        public async Task<IEnumerable<DevelopmentCompany>> GetCompanies()
        {
            return await _databaseContext.DevelopmentCompanies.ToListAsync();
        }
    }
}
