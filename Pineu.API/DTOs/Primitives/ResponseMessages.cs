namespace Pineu.API.DTOs.Primitives {
    public static class ResponseMessages {
        public const string Success = nameof(Success);
        public const string ErrorOccurred = nameof(ErrorOccurred);

        public static class RoleResponse {
            public const string RoleNotFound = nameof(RoleNotFound);
            public const string DuplicateRoleName = nameof(DuplicateRoleName);
        }
    }
}
