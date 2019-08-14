using System;

namespace WebApi.UseCases.GetAll
{
    public sealed class SimpleEntityDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
    }
}
