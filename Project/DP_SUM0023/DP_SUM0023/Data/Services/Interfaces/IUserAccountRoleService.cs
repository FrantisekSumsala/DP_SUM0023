using DP_SUM0023.Data.Models;

namespace DP_SUM0023.Data.Services.Interfaces
{
    public interface IUserAccountRoleService : IDefaultCRUDService<UserAccountRole>
    {
        public Task<UserAccountRole> GetByEnum(EAccountRole enumRole);
        public EAccountRole ToEnumRole(UserAccountRole dbRole);
    }
}
