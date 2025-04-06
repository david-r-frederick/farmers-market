namespace Core.DataModel.Interfaces;

/// <summary>
/// Interface for base entity properties that all database entities should implement
/// </summary>
public interface IBaseEntity
{
    DateTime CreatedOn { get; set; }

    string? CreatedBy { get; set; }

    string? DeletedBy { get; set; }

    DateTime DeletedOn { get; set; }

    int Id { get; set; }

    bool IsActive { get; set; }

    bool IsDeleted { get; set; }

    string? Key { get; set; }

    string? UpdatedBy { get; set; }

    DateTime? UpdatedOn { get; set; }
}