

namespace DomainLayer.Exceptions
{
    public class DeliveyMethodNotFoundException(int id): NotFoundException($"DelivaryMethod With Id{Id} is not Found! ");

    }
}
