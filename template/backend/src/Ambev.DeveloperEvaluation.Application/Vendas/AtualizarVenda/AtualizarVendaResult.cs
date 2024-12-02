﻿using Ambev.DeveloperEvaluation.Domain.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Vendas.AtualizarVenda;

public class AtualizarVendaResult
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }

    public DateTime Date { get; set; }

    public List<SaleItemDto>? Product { get; set; }
}
