using System.ComponentModel;

namespace Pineu.Persistence.Constants.Enums {
    public enum PermissionNames {
        [Description("کاربر")]
        User = 0,

        [Description("دسترسی‌ها")]
        Permission = 1,

        [Description("نقش‌ها")]
        Role = 2,

        [Description("پایگاه داده")]
        Database = 3,
    }
}
