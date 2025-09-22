using System.ComponentModel.DataAnnotations;

namespace FinanceBill.Domain.Entities;

public class Bill
{
    /// <summary>
    /// شناسه
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// نام
    /// </summary>
    [MaxLength(30)]
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>
    [MaxLength(30)]
    public string? Description { get; set; }

    /// <summary>
    /// مبلغ
    /// </summary>
    [Required]
    [Range(1000, 100000000, ErrorMessage = "باید بین 1000 و 100000000 باشد")]
    public double Price { get; set; }

    /// <summary>
    /// ایجاد شده در
    /// </summary>
    [Required]
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// ویرایش شده در
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}
