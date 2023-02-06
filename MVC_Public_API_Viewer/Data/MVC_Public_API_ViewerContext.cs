using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC_Public_API_Viewer.Models;

namespace MVC_Public_API_Viewer.Data
{
    public class MVC_Public_API_ViewerContext : DbContext
    {
        public MVC_Public_API_ViewerContext (DbContextOptions<MVC_Public_API_ViewerContext> options)
            : base(options)
        {
        }

        public DbSet<MVC_Public_API_Viewer.Models.ProductViewModel> ProductViewModel { get; set; } = default!;
    }
}
