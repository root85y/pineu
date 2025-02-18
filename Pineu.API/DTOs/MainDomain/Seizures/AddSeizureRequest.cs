﻿namespace Pineu.API.DTOs.MainDomain.Seizures {
    public sealed record AddSeizureRequest(
        DateTime SeizureDateTime,
        int? SeizureDuration,
        List<AttackType>? AttackTypeList,
        List<string>? InjuryList,
        string? SeverityOfInjury,
        MentalStatusEnum? MentalStatusBeforeSeizure,
        AmountType? AmountOfPhysicalStatusBeforeSeizure,
        List<string>? GeneralStatusBeforeSeizure,
        QualityType? SleepQualityAtTheNightBeforeSeizure,
        List<string>? ActivityAtSeizureTime,
        List<string>? FoodBeforeSeizure,
        AmountType? AmountOfFoodBeforeSeizure,
        ConsumptionType? SmokingConsumption,
        ConsumptionType? AlcoholConsumption,
        MentalStatusEnum? MentalStatusAfterSeizure,
        List<string>? GeneralStatusAfterSeizure);
}
