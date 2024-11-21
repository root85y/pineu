namespace Pineu.Application.Abstractions.Sms;

public interface ISmsPanel {
    Task SendSms(string phoneNumber, int code, string apiKey, int templateId);
}
