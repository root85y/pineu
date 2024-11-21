namespace Pineu.Domain.Errors;
public static class DomainErrors {
    public static class DatabaseBackup {
        public static readonly Error DatabaseBackupNotFound = new("بک آپ دیتابیس یافت نشد");
    }
    public static class SystemFile {
        public static readonly Error FileIsEmpty = new("فایل خالی است");

        public static readonly Error FileIsNotImage = new("فایل عکس نمی باشد");

        public static readonly Error FileIsLarge = new("حجم فایل زیاد است");

        public static readonly Error FileNotFound = new("فایل یافت نشد");
    }
    public static class Banner {
        public static readonly Error BannerNotFound = new("بنر یافت نشد");
    }
    public static class Discount {
        public static readonly Error DiscountNotFound = new("تخفیف یافت نشد");
        public static readonly Error AlreadyBoughtDiscount = new("تخفیف قبلا خریداری شده است");
    }
    public static class MedicalInformation {
        public static readonly Error MedicalInformationNotFound = new("اطلاعات پزشکی یافت نشد");
    }
    public static class Profile {
        public static readonly Error ProfileNotFound = new("پروفایل یافت نشد");
        public static readonly Error NotEnoughScore = new("امتیاز کافی ندارید");
    }
    public static class MentalStatus {
        public static readonly Error MentalStatusNotFound = new("وضعیت روحی یافت نشد");
    }
    public static class NutritionStatus {
        public static readonly Error NutritionStatusNotFound = new("وضعیت تغذیه یافت نشد");
    }
    public static class SleepStatus {
        public static readonly Error SleepStatusNotFound = new("وضعیت خواب یافت نشد");
    }
    public static class WorkoutStatus {
        public static readonly Error WorkoutStatusNotFound = new("وضعیت تحرک یافت نشد");
    }
    public static class News {
        public static readonly Error NewsNotFound = new("خبر یافت نشد");
    }
    public static class Score {
        public static readonly Error ScoreNotFound = new("امتیاز یافت نشد");
    }
    public static class Store {
        public static readonly Error StoreNotFound = new("فروشگاه یافت نشد");
    }
    public static class Seizure {
        public static readonly Error LimitReached = new("ثبت تشنج بیش از حد مجاز روزانه!");
    }
    public static class UserIngredient {
        public static readonly Error UserIngredientNotFound = new("غذا یافت نشد");
    }
    public static class UserMedicine {
        public static readonly Error UserMedicineNotFound = new("دارو یافت نشد");
    }
    public static class PastAntiepilepticMedicine {
        public static readonly Error DoesNotMatch = new("دارو های وارد شده درست نمی باشد");
    }

    public static class FirstName
    {
        public static readonly Func<int, Error> FirstNameTooLong = maxLength => new Error(nameof(FirstNameTooLong));
    }

    public static class LastName
    {
        public static readonly Error LastNameEmpty = new(nameof(LastNameEmpty));

        public static readonly Func<int, Error> LastNameTooLong = maxLength => new Error(nameof(LastNameTooLong));
    }

    public static class Mobile
    {
        public static readonly Error MobileEmpty = new(nameof(MobileEmpty));

        public static readonly Func<int, Error> MobileLength = length => new Error(nameof(MobileLength));
    }

    public static class NationalCode
    {
        public static readonly Error NationalCodeEmpty = new(nameof(NationalCodeEmpty));

        public static readonly Func<int, Error> NationalCodeLength = length => new Error(nameof(NationalCodeLength));
    }
}
