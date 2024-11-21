using Pineu.Application.MainDomain.Banners.Queries.DTOs;
using Pineu.Application.Types.Queries;
using Pineu.Application.Types.Queries.DTOs;

namespace Pineu.API.Controllers.Types {
    public class TypeController(ISender sender) : ApiController(sender) {
        [HttpGet, Route("Aetiology")]
        public async Task<ActionResult<IEnumerable<GetTypeResponse>>> GetAetiologyTypes(string? search, CancellationToken cancellationToken) {
            var query = new GetAllAetiologyTypesQuery(search, null);
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse(res.Value);
        }
        [HttpGet, Route("Consciousness")]
        public async Task<ActionResult<IEnumerable<GetTypeResponse>>> GetConsciousnessTypes(string? search, CancellationToken cancellationToken) {
            var query = new GetAllConsciousnessTypeQuery(search, null);
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse(res.Value);
        }
        [HttpGet, Route("DateTimeUnit")]
        public async Task<ActionResult<IEnumerable<GetTypeResponse>>> GetDateTimeUnitType(string? search, CancellationToken cancellationToken) {
            var query = new GetAllDateTimeUnitTypesQuery(search, null);
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse(res.Value);
        }
        [HttpGet, Route("Drug")]
        public async Task<ActionResult<IEnumerable<GetTypeResponse>>> GetDrugType(string? search, CancellationToken cancellationToken) {
            var query = new GetAllDrugTypesQuery(search, null);
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse(res.Value);
        }
        [HttpGet, Route("DurationOfUse")]
        public async Task<ActionResult<IEnumerable<GetTypeResponse>>> GetDurationOfUseType(string? search, CancellationToken cancellationToken) {
            var query = new GetAllDurationOfUseTypeQuery(search, null);
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse(res.Value);
        }
        [HttpGet, Route("FamilyDiseaseHistory")]
        public async Task<ActionResult<IEnumerable<GetTypeResponse>>> GetFamilyDiseasesHistoryType(string? search, CancellationToken cancellationToken) {
            var query = new GetAllFamilyDiseasesHistoryTypeQuery(search, null);
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse(res.Value);
        }
        [HttpGet, Route("Movement")]
        public async Task<ActionResult<IEnumerable<GetTypeResponse>>> GetMovementType(string? search, CancellationToken cancellationToken) {
            var query = new GetAllMovementTypeQuery(search, null);
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse(res.Value);
        }
        [HttpGet, Route("OtherDisease")]
        public async Task<ActionResult<IEnumerable<GetTypeResponse>>> GetOtherDiseaseType(string? search, CancellationToken cancellationToken) {
            var query = new GetAllOtherDiseaseTypeQuery(search, null);
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse(res.Value);
        }
        [HttpGet, Route("ParentFamilyRelationship")]
        public async Task<ActionResult<IEnumerable<GetTypeResponse>>> GetParentFamilyRelationshipType(string? search, CancellationToken cancellationToken) {
            var query = new GetAllParentFamilyRelationshipTypeQuery(search, null);
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse(res.Value);
        }
        [HttpGet, Route("PastYearComplaint")]
        public async Task<ActionResult<IEnumerable<GetTypeResponse>>> GetPastYearComplaintType(string? search, CancellationToken cancellationToken) {
            var query = new GetAllPastYearComplaintTypeQuery(search, null);
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse(res.Value);
        }
        [HttpGet, Route("Seizure")]
        public async Task<ActionResult<IEnumerable<GetTypeResponse>>> GetSeizureType(string? search, CancellationToken cancellationToken) {
            var query = new GetAllSeizureTypeQuery(search, null);
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse(res.Value);
        }
        [HttpGet, Route("Epilepsy")]
        public async Task<ActionResult<IEnumerable<GetTypeResponse>>> GetEpilepsyType(string? search, CancellationToken cancellationToken) {
            var query = new GetAllEpilepsyTypesQuery(search, null);
            var res = await Sender.Send(query, cancellationToken);
            if (res.IsFailure) return HandleFailure(res);

            return SuccessResponse(res.Value);
        }
    }
}
