using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suma4030349
{
    
    [Table("cliente")]
    public class Resultado
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("id")]
        public int Id { get; set; }
        [Column("nombrecliente")]
        public string? Numero1 { get; set; }
        [Column("movil")]
        public string? Numero2 { get; set; }
        [Column("email")]
        public string? Suma { get; set; }
    }
}
