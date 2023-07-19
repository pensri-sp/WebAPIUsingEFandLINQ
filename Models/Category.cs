using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSSQLStoreAPI.Models;

[Table("Catogories", Schema = "dbo")]
public class Category
{
    [Column("CatagoryId")]
    public int Id {get;set;}

    [Required]
    [Column("CatagoryName" , TypeName = "varchar(64)" , Order = 1)]
    public string CatagoryName{get;set;}

    [Required]
    [Column(Order = 2)]
    public  int  CategoryStatus {get;set;}

}