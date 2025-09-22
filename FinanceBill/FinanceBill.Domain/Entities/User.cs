using System.ComponentModel.DataAnnotations;

namespace FinanceBill.Domain.Entities;

/// <summary>
/// کاربر
/// </summary>
public class User
{
    /// <summary>
    /// شناسه
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// نام
    /// </summary>
    [MaxLength(15)]
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// ایجاد شده در
    /// </summary>
    [Required]
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// ویرایش شده در
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    #region Navigation Property
    public Bill Bill { get; set; }

    #endregion

}
