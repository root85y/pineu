using IPE.SmsIrClient.Models.Requests;
using Pineu.Application.Abstractions.Sms;

namespace Pineu.Infrastructure.SmsPanels {
    internal class SmsPanel : ISmsPanel {
        public async Task SendSms(string phoneNumber, int code, string apiKey, int templateId) {
            var sender = new IPE.SmsIrClient.SmsIr(apiKey);
            VerifySendParameter[] verifySendParameters = [
                new("CODE", code.ToString()),
            ];
            for (int i = 0; i < 3; i++) {
                try {
                    await sender.VerifySendAsync(phoneNumber, templateId, verifySendParameters);
                    break;
                } catch (Exception) {
                    continue;
                }
            }
        }
    }
}
