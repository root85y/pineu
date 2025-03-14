﻿using Pineu.Application.MainDomain.DoctorPrescriptions.Queries.DTOs;

namespace Pineu.Application.MainDomain.AdminPanel.Queries;
public sealed record GetUserDataQuery() : IQuery<PagedResponse<IEnumerable<Profile>>>;
