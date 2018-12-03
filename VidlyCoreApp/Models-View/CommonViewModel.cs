using System;
using Microsoft.EntityFrameworkCore;
using VidlyCoreApp.Models;

namespace VidlyCoreApp.ViewModels
{
    public abstract class CommonViewModel : IDisposable
    {
        public enum FormMode { New, Update };
        protected VidlyDbContext _dbContext;

        public CommonViewModel()
        {
            InitializeDbContext();
        }

        private void InitializeDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<VidlyDbContext>();
            optionsBuilder.UseSqlite("Data Source=vidly.db");

            _dbContext = new VidlyDbContext(optionsBuilder.Options);
        }

        public FormMode Mode { get; set; }


        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
