using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicMigration.Models;

public class Hat
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
    public List<Llamas> Llamas { get; set; }
}
