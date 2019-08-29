using System;
using WebApi;
using WebApi.UseCases;
using WebApi.UseCases.GetAll;

namespace WebApi.UseCases.GetById
{
    public sealed class SimpleEntityDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
    }
}
