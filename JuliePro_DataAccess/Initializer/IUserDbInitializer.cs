using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_DataAccess.Initializer
{
  public interface IUserDbInitializer
  {
    
    Task Initialize();
        Task SeedAsync();
    }
}
