using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MSSQLStoreAPI.Models;

[Table("Products", Schema = "dbo")]
[Comment("ตารางเก็บข้อมูลสินค้า")]
public class Products
{
    [Key] // ถ้าหาก pattern name ของ Id ไม้ได้ลงท้ายด้วย Id ตัวใหญ่ตัวเล็ก จะต้องใส่ [Key] 
    [Column("ProductID")]
    public int Id {get;set;}

    [Required]
    [MaxLength(64)]
    [Column(TypeName = "varchar(64)", Order = 1)]
    public string ProductName {get;set;}

    [Required]
    [Column(TypeName = "decimal(10,2)", Order = 2)] // 10,2 เก็บได้สูงสุด 10 หลัก โดย ทศนิยม 2 ตำแหน่ง (8 หลัก ทศนิยม 2 ต.น.)
    public decimal UnitPrice {get;set;}

    [Required]
    [Column(Order =3)]
    public int UnitStock {get;set;}

    [Required]
    [Column(TypeName = "varchar(128)", Order = 4)]
    public string ProductPicture{get;set;}

    [Column(Order = 5)]
    public DateTime CreatedDate {get;set;} = DateTime.Now;

    [Column(Order = 6)]
    public DateTime ModifiedDate {get;set;} = DateTime.Now;

    [ForeignKey("CatagoryInfo")]
    public int CatagoryId {get;set;}
    public virtual Category CatagoryInfo {get;set;}

    [NotMapped]
    public string CatagoryName{get;set;}
}