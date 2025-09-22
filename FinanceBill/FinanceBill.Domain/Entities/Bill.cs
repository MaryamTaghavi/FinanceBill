namespace FinanceBill.Domain.Entities;

public class Bill
{
    /// <summary>
    /// شناسه
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// نام
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// مبلغ
    /// </summary>
    public double Price { get; set; }

    /// <summary>
    /// ایجاد شده در
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// ویرایش شده در
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}
