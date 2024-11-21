using System.ComponentModel;

namespace Pineu.Persistence.Constants.Enums {
    public enum Policies {
        [Description("افزودن")]
        Create = 0,

        [Description("مشاهده")]
        Read = 1,

        [Description("ویرایش")]
        Update = 2,

        [Description("فعال‌سازی")]
        Activation = 3,

        [Description("نقش‌ها")]
        Role = 4,

        [Description("حذف")]
        Delete = 5,

        [Description("کلمه عبور جدید")]
        Password = 6,

        [Description("پشتیبان گیری")]
        Backup = 7,
    }
}
