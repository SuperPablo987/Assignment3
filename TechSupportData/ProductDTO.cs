using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechSupportData
{
    /*
    * The purpose of this application is to retrieve lightweight data from connected database's product table.
    * The application will control product code, name, version, release date and will handled pulling data from, adding data to and deleting from the database.
    * Created on Apr 7, 2023
    * Author: Peter Thiel
    */
    public class ProductDTO
    {
        public string ProductCode { get; set; } = null!;
        public string Name { get; set; } = null!;
        public decimal Version { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
