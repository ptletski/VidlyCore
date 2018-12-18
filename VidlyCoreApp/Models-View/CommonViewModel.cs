using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VidlyCoreApp.Models;

namespace VidlyCoreApp.ViewModels
{
    public abstract class CommonViewModel : IDisposable
    {
        public enum FormMode { New, Update };
        protected VidlyDbContext _dbContext;
        private ILogger _logger;

        protected CommonViewModel(ILogger logger = null)
        {
            _logger = logger;

            InitializeDbContext();
        }

        private void InitializeDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<VidlyDbContext>();
            optionsBuilder.UseSqlite("Data Source=vidly.db");

            _dbContext = new VidlyDbContext(optionsBuilder.Options);
        }

        public ILogger Logger
        {
            get => _logger;
            set => _logger = value; 
        }

        public FormMode Mode { get; set; }


        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
