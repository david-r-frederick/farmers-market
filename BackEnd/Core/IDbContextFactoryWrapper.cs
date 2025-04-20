namespace Core;

public interface IDbContextFactoryWrapper
{
    IDatabaseContext GetContext();
}

